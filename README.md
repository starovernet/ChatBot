# ChatBot

Simple API for chat bot based on .NET5, can be deployed with Docker, on Windows or Linux. 
Database engine is MySql, but easily can be replaced with any other engine by adding new project and implementing data access interfaces.
Documentation available via /swagger endpoint.
Have 4 API endpoints:
### POST /ChatBot 
Accept application/json mime type with structure:
{
  "botId": "5f74865056d7bb000fcd39ff",
  "message": "hello"
}

response with json stucture { "message": "Some text" }

Also there 3 endpoints to manage responses, protected by API key, same as AI service, accepted key also same as AI service.

### POST /admin/responses

Accept application/json mime type with structure:
{
  "intent": "greeting",
  "response": "hello there"
}
### GET /admin/responses
Accept query parameters for pagination and filter by intent, here is example of query string: ?start=0&pageSize=10&intent=greeting
### DELETE /admin/responses
Accept query paramete with response Id
