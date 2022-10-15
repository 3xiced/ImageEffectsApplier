using System.Drawing;

namespace ImageProcessor.Core;

public interface IFilter
{
    Bitmap ApplyFilter(FilterSettings filterSettings);
    Task<Bitmap> ApplyFilterAsync(FilterSettings filterSettings);
}

