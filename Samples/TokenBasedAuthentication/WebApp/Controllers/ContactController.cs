using System.Threading.Tasks;
using System.Web.Http;

[RoutePrefix("api/Contact")]
public class ContactController : ApiController
{
    [Authorize]
    [Route("")]
    public IHttpActionResult Get()
    {
        return Ok(new Contact[]{
            new Contact(){ID=1, Name="Ori" },
            new Contact(){ID=2, Name="Roni" },
        });
    }
}

public class Contact
{
    public int ID { get; set; }
    public string Name { get; set; }
}
