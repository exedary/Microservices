using System;

namespace Warranty.Api.Domain
{
    public class Warranty
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Guid ItemUid { get; set; }
        public string Status { get; set; }
        public TimeSpan WarrantyDate { get; set; }

        public static Warranty Create(Guid itemUid, TimeSpan warrantyDate, string comment = null)
        {
            return new Warranty
            {
                Comment = comment,
                ItemUid = itemUid,
                Status = WarrantyStatuses.OnWarranty,
                WarrantyDate = warrantyDate
            };
        }

        public void ChangeStatusToCancel()
        {
            if (Status == WarrantyStatuses.RemovedFromWarranty)
            {
                Status = WarrantyStatuses.RemovedFromWarranty;
                WarrantyDate = TimeSpan.Zero;
            }
            else throw new InvalidOperationException("Item already in status: RemovedFromWarranty");
        }

        public void ChangeStatusToUse()
        {
            Status = WarrantyStatuses.UseWarranty;
        }

        public string GetStatus(bool isInStock)
        {
            return Status != WarrantyStatuses.OnWarranty ? "REFUSED" : isInStock ? "RETURN" : "FIXING";
        }
    }
}
