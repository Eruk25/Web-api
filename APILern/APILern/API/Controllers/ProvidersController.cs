using APILern.Application.DTO;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace APILern.Controller;

[ApiController]
[Route("[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderRepository _repository;
    private readonly IProviderService _providerService;

    public ProvidersController(IProviderRepository repository, IProviderService providerService)
    {
        _repository = repository;
        _providerService = providerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Provider>>> GetProvidersAsync()
    {
        var providers = await _providerService.GetAllAsync();
        return Ok(providers);
    }

    [HttpGet("{id}", Name = "GetProviderByIdAsync")]
    public async Task<ActionResult<Provider>> GetProviderByIdAsync(int id)
    {
        var provider = await _providerService.GetByIdAsync(id);

        return provider is null ? NotFound() : Ok(provider);
    }
    [HttpPost]
    public async Task<ActionResult> AddProviderAsync([FromBody] CreateProviderDto dto)
    {
        var createId = await _providerService.AddAsync(dto);
        return CreatedAtRoute("GetProviderByIdAsync", new { id = createId }, new { id = createId });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProviderAsync(int id, [FromBody] UpdateProviderDto dto)
    {
        var success = await _providerService.UpdateAsync(id, dto);

        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProviderAsync(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}
