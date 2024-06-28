using AccountManagement.Application.Accounts.Commands.CreateAccount;
using AccountManagement.Application.Accounts.Commands.UpdateAccount;
using AccountManagement.Application.Accounts.Queries.GetAccountById;
using AccountManagement.Application.Accounts.Queries.GetAccounts;
using AccountManagement.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : APIControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _mediator.Send(new GetAccountsQuery());
            return Ok(accounts);
        }

        [HttpGet("{id:int}", Name = "GetAccountById")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery() { Id = id});
            if(account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountCommand createCommand)
        {
            var createdAccount = await _mediator.Send(createCommand);
            return CreatedAtRoute("GetAccountById", new { id = createdAccount.Id }, createdAccount);            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAccountCommand updateCommand)
        {
            if(id != updateCommand.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(updateCommand);
            return NoContent();
        }
    }
}
