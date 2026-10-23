# Building Materials Enterprise Management System
### Desktop ERP for Inventory, Procurement, and Financial Operations

[![Platform](https://img.shields.io/badge/Platform-.NET%20Framework-blue.svg)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Database](https://img.shields.io/badge/Database-SQL%20Server-red.svg)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)](LICENSE)

A Windows desktop management application developed in C# and Windows Forms, engineered for enterprise operations in the building materials industry. The system supports full-cycle inventory control, supplier coordination, stock dispatching, and formal audit reporting.

---

## Functional Modules

The application is structured into domain-specific modules:

- **Authentication & Security (`System`):** Role-based access control, encrypted credential verification, and user permission administration (`frmLogin`, `frmUserManagement`).
- **Master Data Catalog (`MasterData`):** Comprehensive registration and maintenance of material categories, product inventories, and supplier profiles (`frmMaterialManagement`, `frmCategoryManagement`, `frmSupplierManagement`).
- **Warehouse Operations (`Operation`):** Stock receipt generation, dispatch tracking, batch auditing, and automated inventory adjustments (`frmStockReceipt`).
- **Reporting & Printing (`Report`):** Aggregated revenue metrics, inventory turnover analysis, and formal invoice/receipt printing generation (`frmPrintReceipt`, `frmStatisticsReport`).

---

## Solution Structure

```text
building-materials-management/
├── building-materials-management.sln       # Visual Studio solution file
├── packages/                               # NuGet package cache
└── building-materials-management/
    ├── App.config                          # Application configuration and connection strings
    ├── Program.cs                          # Application main entry point
    ├── packages.config                     # NuGet dependency manifest
    ├── Classes/                            # Data access objects and business helper classes
    ├── MasterData/                         # Forms for Category, Material, and Supplier entities
    ├── Operation/                          # Forms for Stock In / Stock Out receipts
    ├── Report/                             # Forms for Statistical Reports and Document Printing
    └── System/                             # Forms for Authentication and System Users
```

---

## Prerequisites and Deployment

### 1. System Requirements
- Microsoft Windows 10/11
- .NET Framework 4.7.2 or higher
- Microsoft SQL Server 2016 or later
- Visual Studio 2019 / 2022 (Community or higher)

### 2. Build and Execution
1. Open `building-materials-management.sln` in **Visual Studio**.
2. Restore NuGet dependencies via **Package Manager Console**:
   ```powershell
   Update-Package -reinstall
   ```
3. Update the database connection string in `App.config` under `<connectionStrings>` to match your SQL Server instance.
4. Execute database initialization scripts (tables, constraints, stored procedures).
5. Set active build configuration to `Release` or `Debug` and press `F5` to compile and launch.

---

## Core Technologies

- **Framework:** .NET Framework (Windows Forms)
- **Programming Language:** C#
- **Database Engine:** Microsoft SQL Server
- **Reporting Framework:** RDLC / Crystal Reports
- **Data Access:** ADO.NET / Typed DataSets

---

## License

This project is licensed under the MIT License - see the LICENSE file for details.
