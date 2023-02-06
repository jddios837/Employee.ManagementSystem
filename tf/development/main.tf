terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.42.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

data "azurerm_client_config" "current" {}


# Create Resource Group
resource "azurerm_resource_group" "rg" {
  location = var.group_location
  name     = var.group_name
  tags = {
    environment = "dev"
  }
}

# Create Keyvault
#resource "azurerm_key_vault" "keyvault" {
#  depends_on                  = [azurerm_resource_group.rg]
#  name                        = var.keyvault_name
#  location                    = azurerm_resource_group.rg.location
#  resource_group_name         = azurerm_resource_group.rg.name
#  enabled_for_disk_encryption = true
#  tenant_id                   = data.azurerm_client_config.current.tenant_id
#  soft_delete_retention_days  = 7
#  purge_protection_enabled    = false
#
#  sku_name = "standard"
#
#  access_policy {
#    tenant_id = data.azurerm_client_config.current.tenant_id
#    object_id = data.azurerm_client_config.current.object_id
#
#    key_permissions = [
#      "Get",
#    ]
#
#    secret_permissions = [
#      "Get", "Backup", "Delete", "List", "Purge", "Recover", "Restore"
#    ]
#
#    storage_permissions = [
#      "Get",
#    ]
#  }
#  tags = {
#    Environment = "Dev"
#    Project     = var.tag_project
#  }
#
#}

# Create Secret
#resource "azurerm_key_vault_secret" "admin_secret" {
#  name         = "ConnectionStrings--EmployeeContext"
#  value        = "TEST DONE"
#  key_vault_id = azurerm_key_vault.keyvault.id
#  depends_on   = [azurerm_key_vault.keyvault]
#}

resource "azurerm_mssql_server" "ms_sql_server" {
  name                         = "emp-mg-sqlserver"
  resource_group_name          = azurerm_resource_group.rg.name
  location                     = azurerm_resource_group.rg.location
  version                      = "12.0"
  administrator_login          = "4dm1n157r470r"
  administrator_login_password = "4-v3ry-53cr37-p455w0rd"
}

resource "azurerm_mssql_database" "ms_sql_db" {
  name           = "acctest-db-d"
  server_id      = azurerm_mssql_server.ms_sql_server.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  read_scale     = true
  sku_name       = "Basic"
  zone_redundant = true

  tags = {
    Environment = "Dev"
    Project     = var.tag_project
  }
}