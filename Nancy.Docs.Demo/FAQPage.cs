namespace Nancy.Docs.Demo
{
    public class FAQPage : IPageIdentifier
    {
        public string Name => "FAQ";
        public string Path { get; set; }
    }
}