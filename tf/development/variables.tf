##################################
# Azure Resource Group variables #
##################################

variable "group_name" {
  type        = string
  description = "Group Resource Name"
  default     = "EmployeeManagementSystem"
}

variable "group_location" {
  type        = string
  description = "Group Resource Location, by default 'westus'"
  default     = "westus"
}

##################################
# Azure Key Vault variables #
##################################
variable "keyvault_name" {
  type        = string
  description = "Key Vault Name"
  default     = "emp-mg-kv"
}

variable "tag_project" {
  type        = string
  description = "Tag Project Name"
  default     = "EmployeeManagementSystem"
}