using Nancy.ModelBinding;

namespace Nancy.Docs.Demo
{

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["HomeRoute", "/"] = _ => "Hi";

            Get["GetUsers", "/users"] = _ => new[] { new User { Name = "Vincent Vega", Age = 45 } };

            Post["PostUsers", "/users"] = _ =>
                {
                    var result = this.BindAndValidate<User>();

                    if (!ModelValidationResult.IsValid)
                    {
                        return Negotiate.WithModel(new { Message = "Oops" })
                            .WithStatusCode(HttpStatusCode.UnprocessableEntity);
                    }

                    return Negotiate.WithModel(result).WithStatusCode(HttpStatusCode.Created);
                };
        }
    }
}
