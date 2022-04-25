﻿using Microsoft.AspNetCore.Mvc;
using NeanderBank.Business.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace NeanderBank.Business.Services
{
    public class ResponseService : ControllerBase, IResponseService
    {
        private readonly List<string> _errors;
        public ResponseService()
        {
            _errors = new List<string>();
        }

        public string DivergentId(int parameterId, int entityId)
        {
            string message = $"Entity Id ({entityId}) is different from parameter Id ({parameterId}).";
            AddError(message);
            return message;
        }

        public string NullValue(string[] nullValues)
        {
            string message = "Cliente possui valor obrigatório nulo:" + nullValues.Select(nv => $"\n-{nv}");
            AddError(message);
            return message;
        }

        public string TruncatedString(string[] truncatedStrings)
        {
            string message = "O limite máximo de caracteres foi excedido:" + truncatedStrings.Select(ts => $"\n{ts.Split(',')[0]} => Informado: {ts.Split(',')[1]}, Max: {ts.Split(',')[2]}");
            AddError(message);
            return message;
        }






        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddError(string[] errors)
        {
            _errors.AddRange(errors);
        }

        public void AddError(IEnumerable<string> notificacao)
        {
            _errors.AddRange(notificacao);
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        public bool HasError()
        {
            return _errors.Any();
        }
    }
}
