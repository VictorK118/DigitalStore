﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("SmartphonesInOrders")]
public class SmartphonesInOrdersEntity: BaseEntity
{
    public int Amount { get; set; }
    
    public int SmartphoneId { get; set; }
    public CitiesEntity Smartphone { get; set; }
    
    public int OrderId { get; set; }
    public OfflineStoresEntity Order { get; set; }
}