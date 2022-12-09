# create a azure resource group eastus
az login
az group create --name myResourceGroup --location eastus


# create an azure container registry
# this is the same software (docker hub) 
# azure offers this as software as service

az acr create --resource-group myResourceGroup --name acrsrini09dec200 --sku Basic


# Log in to Azure Container Registry

az acr login --name acrsrini09dec200
