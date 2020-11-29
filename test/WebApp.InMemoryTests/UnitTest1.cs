using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TestStack.BDDfy;

namespace WebApp.InMemoryTests
{
    public class ImportRecipeRequest
    {
        public string Name { get; set; }
        public string IngredientList { get; set; }
        public string InstructionList { get; set; }
    }

    public class IngredientContract
    {
        public string Quantity { get; set; }
        public string Name { get; set; }
    }

    public class RecipeContract
    {
        public string Name { get; set; }
        public string[] Instructions { get; set; }
        public IngredientContract[] Ingredients { get; set; }
        public string Id { get; internal set; }
        public int Servings { get; internal set; }
        public double Preparation { get; internal set; }
    }

    [TestFixture]
    public class RecipeCreationFeature : FeatureBase
    {
        private ImportRecipeRequest _request;
        private RecipeContract _response;

        [Test]
        public void Test1()
        {
            this.Given(_ => A_recipe_import_request())
                .When(_ => I_make_a_request())
                .Then(_ => Response_code_is(HttpStatusCode.Created))
                .BDDfy();
        }

        private void A_recipe_import_request()
        {
            _request = new ImportRecipeRequest
            {
                Name = "recipe-name",
                IngredientList = "1 tsp a\n1 cup b",
                InstructionList = "Do A\n\nDo B"
            };
        }

        private async Task I_make_a_request()
        {
            _response = await SendAsync<ImportRecipeRequest, RecipeContract>("/api/recipes/import", _request);
        }

        private void Response_code_is(HttpStatusCode statusCode)
        {
            Assert.That(_lastResponseMessage, Is.EqualTo(statusCode));
        }
    }
}