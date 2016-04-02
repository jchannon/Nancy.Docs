namespace Nancy.Docs.Demo
{
    public class FaqPageIdentifier : IPageIdentifier
    {
        public string Name => "FAQ";
        public string Path => "StaticDocs/faq.md";
    }
}