using System.Collections.Generic;

namespace NeanderBank.Business.Interfaces.Services
{
    public interface IResponseService
    {
        string DivergentId(int parameterId, int entityId);


        void AddError(string error);
        void AddError(string[] errors);
        void AddError(IEnumerable<string> notificacao);
        List<string> GetErrors();
        bool HasError();
    }
}
