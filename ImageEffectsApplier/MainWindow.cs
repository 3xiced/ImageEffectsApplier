using ImageProcessor.Core;
using ImageProcessor.Core.Filters;
using System.Drawing.Imaging;

namespace ImageEffectsApplier;

public partial class MainWindow : Form
{
    #region Properties

    FilterApplier FilterApplier { get; set; }

    IFilter ContrastFilter { get; set; }

    IFilter SobelFilter { get; set; }

    IFilter GrayscaleFilter { get; set; }

    IFilter PrewittFilter { get; set; }

    IFilter ScharrFilter { get; set; }

    Bitmap LoadedImage { get; set; }

    Dictionary<int, Dictionary<IFilter, Bitmap>> LayerFilterImage { get; set; }

    #endregion

    public MainWindow()
    {
        InitializeComponent();

        FilterApplier = new FilterApplier();
        ContrastFilter = new Contrast();
        SobelFilter = new Sobel();
        GrayscaleFilter = new Grayscale();
        PrewittFilter = new Prewitt();
        ScharrFilter = new Scharr();

        LayerFilterImage = new() { { 0, null } };

        effectsComboBox.SelectedIndex = 0;
    }

    private void openFileButton_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog dlg = new OpenFileDialog())
        {
            dlg.Title = "Open Image";
            dlg.Filter = "PNG(*.png)|*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = LoadedImage = new Bitmap(dlg.FileName);
                LayerFilterImage = new() { { 0, null } };
            }
        }
    }

    private void saveButton_Click(object sender, EventArgs e)
    {

        using (SaveFileDialog dlg = new SaveFileDialog())
        {
            dlg.Filter = "PNG(*.png)|*.png";
            dlg.Title = "Save Image";
            dlg.FileName = "image.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(dlg.FileName, ImageFormat.Png);
            }
        }
    }

    private void effectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (effectsComboBox.SelectedIndex)
        {
            case 0: // No filter
                gradientGroupBoxSettings.Visible = false;
                contrastGroupBoxSettings.Visible = false;
                LayerFilterImage = new() { { 0, null } };
                pictureBox.Image = LoadedImage;
                break;
            case 1: // Gradient
                gradientGroupBoxSettings.Visible = true;
                contrastGroupBoxSettings.Visible = false;
                LayerFilterImage = new() { { 0, null } };
                pictureBox.Image = LoadedImage;
                break;
            case 2: // Contrast
                contrastGroupBoxSettings.Visible = true;
                gradientGroupBoxSettings.Visible = false;
                LayerFilterImage = new() { { 0, null } };
                pictureBox.Image = LoadedImage;
                break;
            default:
                break;
        }
    }

    private void contrastTrackBar_Scroll(object sender, EventArgs e) => ApplyFilter(ContrastFilter, new FilterSettings() { FilterStrength = contrastTrackBar.Value });

    private void contrastOption2_CheckedChanged(object sender, EventArgs e)
    {
        if (contrastOption2.Checked)
            ApplyFilter(GrayscaleFilter);
    }

    private void contrastOption1_CheckedChanged(object sender, EventArgs e)
    {
        if (contrastOption1.Checked)
        {
            RemoveFilterByName(GrayscaleFilter);
            ApplyFilter(ContrastFilter, new FilterSettings() { FilterStrength = contrastTrackBar.Value });
        }
    }

    private void gradientOption1_CheckedChanged(object sender, EventArgs e)
    {
        if (gradientOption1.Checked)
        {
            LayerFilterImage = new() { { 0, null } };
            ApplyFilter(SobelFilter);
        }
    }

    private void gradientOption2_CheckedChanged(object sender, EventArgs e)
    {
        if (gradientOption2.Checked)
        {
            LayerFilterImage = new() { { 0, null } };
            ApplyFilter(ScharrFilter);
        }
    }

    private void gradientOption3_CheckedChanged(object sender, EventArgs e)
    {
        if (gradientOption3.Checked)
        {
            LayerFilterImage = new() { { 0, null } };
            ApplyFilter(PrewittFilter);
        }
    }
    private async Task ApplyFilter(IFilter filter, FilterSettings? additionalFilterSettings = null)
    {
        additionalFilterSettings ??= new FilterSettings();

        FilterApplier.Filter = filter;

        // Define what image to use
        Bitmap image;
        int maxLayer = LayerFilterImage.Keys.Max();
        bool isNewLayer = true;
        if (maxLayer == 0)
            image = LoadedImage ?? throw new FileNotFoundException("Image file not loaded.");
        else
        {
            var filterImage = LayerFilterImage.GetValueOrDefault(LayerFilterImage.Keys.Max());
            if (filterImage.ContainsKey(filter))
            {
                if (maxLayer == 1)
                    image = LoadedImage ?? throw new FileNotFoundException("Image file not loaded.");
                else
                {
                    var key = LayerFilterImage.GetValueOrDefault(maxLayer - 1).Keys.First();
                    image = LayerFilterImage.GetValueOrDefault(maxLayer - 1).GetValueOrDefault(key);
                }
                isNewLayer = false;
            }
            else
            {
                var key = filterImage.Keys.First();
                image = filterImage.GetValueOrDefault(key);
            }
        }

        // Apply filter async
        var filterSettings = additionalFilterSettings;
        filterSettings.Image = (Bitmap)image.Clone();
        var processedImage = await FilterApplier.ProcessImage(filterSettings);

        pictureBox.Image = processedImage;

        // Write new data to LayerFilterImage
        if (isNewLayer)
            LayerFilterImage.Add(maxLayer + 1, new Dictionary<IFilter, Bitmap>() { { filter, processedImage } });
        else
            LayerFilterImage[maxLayer] = new Dictionary<IFilter, Bitmap>() { { filter, processedImage } };

        // Collect garbage
        GC.Collect();
    }

    private void RemoveFilterByName(IFilter filter)
    {
        int maxLayer = LayerFilterImage.Keys.Max();
        if (maxLayer == 0)
            return;

        // Sort LayerFilterImage by key
        var sortedDict = from entry in LayerFilterImage orderby entry.Key ascending select entry;
        LayerFilterImage = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);

        bool found = false;
        foreach (var kvp in LayerFilterImage)
        {
            // Skip null object
            if (kvp.Key == 0)
                continue;
            if (kvp.Value.Keys.First() == filter)
            {
                LayerFilterImage.Remove(kvp.Key);
                found = true;
                continue;
            }
            if (found)
                LayerFilterImage.Remove(kvp.Key);
        }
        if (LayerFilterImage.Keys.Max() != 0)
            pictureBox.Image = LayerFilterImage[LayerFilterImage.Keys.Max()].Values.First();
        else
            pictureBox.Image = LoadedImage;
    }
}