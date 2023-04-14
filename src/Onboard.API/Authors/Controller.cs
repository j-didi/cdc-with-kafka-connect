using Microsoft.AspNetCore.Mvc;

namespace Onboard.API.Authors;

[ApiController]
[Route("author")]
public class Controller : ControllerBase
{
    private readonly IRepository _repository;

    public Controller(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _repository.GetAll());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _repository.GetById(id);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] Command command)
    {
        var author = new Author
        {
            Name = command.Name,
            Cpf = command.Cpf,
            Email = command.Email,
            Phone = command.Phone
        };

        await _repository.Save(author);
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Command author)
    {
        var result = await _repository.GetById(id);

        if (result == null)
            return NotFound();

        result.Name = author.Name;
        result.Cpf = author.Cpf;
        result.Email = author.Email;
        result.Phone = author.Phone;
        
        await _repository.Update(result);
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var author = await _repository.GetById(id);
        
        if (author == null)
            return NotFound();
        
        await _repository.Delete(id);
        return Ok();
    }
}