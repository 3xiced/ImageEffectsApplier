using System.Drawing;

namespace ImageProcessor.Core;

public class FilterApplier
{
    public IFilter Filter { get; set; }

    public FilterApplier(IFilter _filter)
    {
        Filter = _filter;
    }

    public FilterApplier()
    {
        Filter = null;
    }

    public async Task<Bitmap> ProcessImage(FilterSettings filterSettings) => await Filter.ApplyFilterAsync(filterSettings);
}

