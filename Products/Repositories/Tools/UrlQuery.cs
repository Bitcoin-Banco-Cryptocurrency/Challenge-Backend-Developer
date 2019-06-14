using System;

public class UrlQuery
{
    public string Genres { get; set; }
    public string Illustrator { get; set; }
    public string Published { get; set; }
    public string Author { get; set; }
    public string SortPriceType {get; set;}
    public bool HaveFilter => !string.IsNullOrEmpty(Genres) || !string.IsNullOrEmpty(Illustrator) ||
                              !string.IsNullOrEmpty(Published) || !string.IsNullOrEmpty(Author);
}