﻿using DigitacaoProposta.Dominio.GravarProposta.Aplicacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.InputModel;

namespace DigitacaoProposta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {

        [HttpPost("criar")]
        public async Task<IActionResult> CriarProposta(
            [FromBody] PropostaInputModel input,
            [FromServices] CriarPropostaHandler handler,
            CancellationToken cancellationToken)
        {
            var command = new CriarPropostaCommand(
                CpfAgente: input.CpfAgente,
                CpfCliente: input.CpfCliente,
                ValorEmprestimo: input.ValorEmprestimo,
                NumeroParcelas: input.NumeroParcelas,
                Refinanciamento: input.Refinanciamento,
                CodigoConveniada: input.CodigoConveniada
            );

            var result = await handler.Handle(command, cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

    }
}
