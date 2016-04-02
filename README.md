# Nancy.Docs

## Introduction

Nancy.Docs brings a solution to how to document your API. It builds on top of the idea of Swagger in which you can document route information such as the possible response codes, required body and response body.  This library takes this one step further and allows you to have documentation separate from route information.  This library also allows you to have sections for each resource.  So for example you can have a generic page of documentation which you write in Markdown, you can have a page of information about each route for a resource or you can have a page of information about each route for a resource as well as multiple notes that you may want to include, again these are written in Markdown.  Please run the [demo](https://github.com/jchannon/Nancy.Docs/tree/master/Nancy.Docs.Demo) to see this in action.

###Usage

Navigating to `/docs` in your app will return links to documentation for resources and any documentation pages you may have:

```
[
	{
		name: "FAQ",
		link: "/docs/pages/FAQ"
	}, 
	{
		name: "HowTo",
		link: "/docs/pages/HowTo"
	}, 
	{
		name: "/users",
		link: "/docs/api/users"
	}
]
```

`Get["/api/{resourcepath}"]` so usage of `/docs/api/users` will return:

```
{
	"routeData": [{
		"consumes": [],
		"produces": [],
		"responseMessages": [{
			"code": 200,
			"message": "Everything will be OK"
		}],
		"parameters": [],
		"apiPath": "/",
		"resourcePath": "/users",
		"name": "HomeRoute",
		"method": "GET"
	}, {
		"consumes": [],
		"model": "Nancy.Docs.Demo.User, Nancy.Docs.Demo",
		"produces": [],
		"responseMessages": [],
		"parameters": [],
		"notes": "This returns a list of users from our awesome app",
		"summary": "The list of users",
		"apiPath": "/users",
		"resourcePath": "/users",
		"name": "GetUsers",
		"method": "GET"
	}, {
		"consumes": [],
		"model": "Nancy.Docs.Demo.User, Nancy.Docs.Demo",
		"produces": [],
		"responseMessages": [{
			"code": 201,
			"message": "Created a User"
		}, {
			"code": 422,
			"message": "Invalid input"
		}],
		"parameters": [{
			"name": "body",
			"paramType": "Body",
			"description": "A User object",
			"required": true,
			"defaultValue": {
				"name": "fred",
				"age": 21,
				"dateOfBirth": "\/Date(-62135596800000+0000)\/",
				"role": "User"
			},
			"parameterModel": "Nancy.Docs.Demo.User, Nancy.Docs.Demo"
		}],
		"notes": "Creates a user with the shown schema for our awesome app",
		"summary": "Create a User",
		"apiPath": "/users",
		"resourcePath": "/users",
		"name": "PostUsers",
		"method": "POST"
	}],
	"notes": {
		"intro": "# Introduction\r\n\r\nCupcake ipsum dolor sit amet. Candy canes tart jelly pudding sugar plum. Lemon drops biscuit cake wafer ice cream gingerbread. Bonbon candy marzipan pudding croissant lemon drops oat cake jelly beans. Gummies gummi bears toffee. Cotton candy gummi bears pie chocolate cake cake. Cake tootsie roll fruitcake pie. Pudding jelly-o caramels bonbon bonbon icing cupcake bonbon danish. Chupa chups fruitcake halvah oat cake chupa chups. Gummies candy wafer brownie apple pie gummies. Candy sweet roll cookie candy canes gummies gummi bears candy souffl\u00E9 jelly beans. Chocolate croissant souffl\u00E9 chupa chups.\r\n\r\n",
		"other": "# Some section\r\n\r\nCupcake ipsum dolor sit amet. Candy canes tart jelly pudding sugar plum. Lemon drops biscuit cake wafer ice cream gingerbread. Bonbon candy marzipan pudding croissant lemon drops oat cake jelly beans. Gummies gummi bears toffee. Cotton candy gummi bears pie chocolate cake cake. Cake tootsie roll fruitcake pie. Pudding jelly-o caramels bonbon bonbon icing cupcake bonbon danish. Chupa chups fruitcake halvah oat cake chupa chups. Gummies candy wafer brownie apple pie gummies. Candy sweet roll cookie candy canes gummies gummi bears candy souffl\u00E9 jelly beans. Chocolate croissant souffl\u00E9 chupa chups."
	}
}
```
`Get["/pages/{pagename}"]` so usage of `docs/pages/FAQ` renders converted markdown to HTML
