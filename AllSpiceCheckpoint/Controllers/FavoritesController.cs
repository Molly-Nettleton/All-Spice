namespace AllSpiceCheckpoint.FavoritesController;
[Authorize]
[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _rs;

  public FavoritesController(Auth0Provider auth0Provider, FavoritesService rs)
  {
    _auth0Provider = auth0Provider;
    _rs = rs;
  }
}