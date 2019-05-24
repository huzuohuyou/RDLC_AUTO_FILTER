namespace InhospitalIndicators.Service.Views.Interfaces
{
    public interface ICanAddRemoveUc
    {
        void DoAdd(IamUc uc);

        void DoRemove(IamUc uc);

        void ReFreshUc();
    }
}
