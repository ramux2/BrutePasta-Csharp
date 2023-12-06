# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.2"
    }
  }

  required_version = ">= 1.1.0"
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "BrutePastaDEV-RG"
  location = "westus2"
}

resource "azurerm_service_plan" "brutepasta_service_plan" {
  name = "brutepasta_service_plan"
  resource_group_name = azurerm_resource_group.name
  location = azurerm_resource_group.location
  sku_name = "F1"
  os_type = "Windows"
}

resource "azurerm_windows_web_app" "brutepasta-webapp" {
  name = "brutepasta-dev"
  resource_group_name = azurerm_resource_group.name
  location = azurerm_resource_group.location
  service_plan_id = azurerm_service_plan.service_plan_id

  site_config {}
}