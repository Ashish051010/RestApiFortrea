using Api.Automation.Fortrea;
using Api.Automation.Fortrea.Models.Request;
using Api.Automation.Fortrea.Models.Response;
using Api.Automation.Fortrea.Utility;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;


[Binding]
public class CreateUserSteps

{

    private CreateUseReq createUseReq;

    private RestResponse restResponse;
    private ScenarioContext scenarioContext;
    private HttpStatusCode statusCode;

    public CreateUserSteps(CreateUseReq createUseReq, ScenarioContext scenarioContext)
    {
        this.createUseReq = createUseReq;
        this.scenarioContext = scenarioContext; 
        
    }
    [Given(@"user with name ""(.*)""")]
    public void GivenUserWithName(string name)
    {
       createUseReq.name = name;
    }

    [Given(@"user with job ""(.*)""")]
    public void GivenUserWithJob(string job)
    {
       createUseReq.job = job;
    }

    [When(@"send request to create user")]
    public async Task WhenSendRequestToCreateUser()
    {
        var api = new APIClient();
        restResponse = await api.createUser<CreateUseReq>(createUseReq);
    }

    [Then(@"validate user is created")]
    public void ThenValidateUserIsCreated()
    {
        statusCode= restResponse.StatusCode;
        var code = (int)statusCode;
       Assert.AreEqual(201 , code);

       var content= HandleContent.GetContent<CreateUserRes>(restResponse);
        Assert.AreEqual(createUseReq.name,content.name);
        Assert.AreEqual(createUseReq.job, content.job);
    }
}
