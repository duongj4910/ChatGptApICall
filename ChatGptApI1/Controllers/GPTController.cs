using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;





namespace ChatGptApI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GPTController : Controller
    {

        [HttpGet]
        [Route("UseChatGPT")]
       
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }

            return Ok(OutPutResult);
        }
    }

}
