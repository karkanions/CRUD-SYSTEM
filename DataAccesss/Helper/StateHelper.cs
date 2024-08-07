using System.Data.Entity;
using static DataAccess.Helper.Enums;

namespace DataAccess.Helper
{
    public static class StateHelper
    {
        public static ModificationType GetModificationTypebyEntityState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return ModificationType.Insert;
                case EntityState.Deleted:
                    return ModificationType.Delete;
                case EntityState.Modified:
                    return ModificationType.Update;
                default:
                    return ModificationType.Insert;
            }

        }
    }
}
