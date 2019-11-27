﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        [XmlElement(ElementName = "TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}