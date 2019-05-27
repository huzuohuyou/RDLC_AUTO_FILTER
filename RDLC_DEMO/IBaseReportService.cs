using System.Data;
using System.Threading.Tasks;

namespace InhospitalIndicators.Service
{
    public interface IBaseReportService
    {
        Task<DataTable> DoTable();
    }
}
