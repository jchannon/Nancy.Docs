using System;
using Nancy.Hosting.Self;
using Nancy.Metadata.Modules;

namespace Nancy.Docs.Demo
{

    public class HomeMetadataModule : MetadataModule<DocsRouteData>
    {
        public HomeMetadataModule()
        {
            Describe["HomeRoute"] = description => description.AsNancyDocs(with =>
                {
                    with.ResourcePath("/users");
                    with.ApiPath("/");
                    with.Response(200, "Everything will be OK");
                }
            );

            Describe["GetUsers"] = description => description.AsNancyDocs(with =>
                {
                    with.ResourcePath("/users");
                    with.Summary("The list of users");
                    with.Notes("This returns a list of users from our awesome app");
                    with.Model<User>();
                });

            Describe["PostUsers"] = description => description.AsNancyDocs(with =>
                {
                    with.ResourcePath("/users");
                    with.Summary("Create a User");
                    with.Response(201, "Created a User");
                    with.Response(422, "Invalid input");
                    with.Model<User>();
                    with.BodyParam<User>("A User object", required: true, defaultValue:new User() {Age = 21, Name = "fred"});
                    with.Notes("Creates a user with the shown schema for our awesome app");
                });


        }
    }
}
