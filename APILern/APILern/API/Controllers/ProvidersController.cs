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
    private readonly IProviderService _providerService;

    public ProvidersController(IProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProviderResponseDto>>> GetProvidersAsync()
    {
        var providers = await _providerService.GetAllAsync();
        return Ok(providers);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}", Name = "GetProviderByIdAsync")]
    public async Task<ActionResult<ProviderResponseDto>> GetProviderByIdAsync(int id)
    {
        var provider = await _providerService.GetByIdAsync(id);

        return provider is null ? NotFound() : Ok(provider);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult> AddProviderAsync([FromBody] CreateProviderDto dto)
    {
        var createId = await _providerService.AddAsync(dto);
        return CreatedAtRoute("GetProviderByIdAsync", new { id = createId }, new { id = createId });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProviderAsync(int id, [FromBody] UpdateProviderDto dto)
    {
        var success = await _providerService.UpdateAsync(id, dto);

        return success ? Ok() : NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProviderAsync(int id)
    {
        await _providerService.DeleteAsync(id);

        return NoContent();
    }
}
