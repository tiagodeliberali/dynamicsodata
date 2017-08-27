﻿using Newtonsoft.Json;
using System;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class Customer
    {
        [JsonProperty("@odata.etag")]
        public string odataetag { get; set; }

        [JsonProperty("dataAreaId")]
        public string DataAreaId { get; set; }

        public string CustomerAccount { get; set; }
        public string WarehouseId { get; set; }
        public string IsPurchRequestUsed { get; set; }
        public string CustomerRebateGroupId { get; set; }
        public string DeliveryFreightZone { get; set; }
        public string AddressDescription { get; set; }
        public string NumberSequenceGroup { get; set; }
        public string InvoiceAccount { get; set; }
        public string LineDiscountCode { get; set; }
        public string AddressState { get; set; }
        public string AddressBooks { get; set; }
        public string AddressCity { get; set; }
        public string InvoiceAddressStreet { get; set; }
        public string PartyState { get; set; }
        public string PaymentMethod { get; set; }
        public string IsExcludedFromCollectionFeeCalculation { get; set; }
        public string SiteId { get; set; }
        public int AddressLatitude { get; set; }
        public string AddressZipCode { get; set; }
        public string PANReferenceNumber { get; set; }
        public string DeliveryAddressDescription { get; set; }
        public string IRS1099CIndicator { get; set; }
        public string PrimaryContactURLDescription { get; set; }
        public string IsIncomingFiscalDocumentGenerated { get; set; }
        public string PrimaryContactPhoneExtension { get; set; }
        public string InvoiceAddressLocationId { get; set; }
        public string AddressBrazilianIE { get; set; }
        public int PersonAnniversaryDay { get; set; }
        public string CreditCardAddressVerification { get; set; }
        public string PersonProfessionalTitle { get; set; }
        public string GiroType { get; set; }
        public string IsOrderNumberReferenceUsed { get; set; }
        public string AddressCounty { get; set; }
        public string PrimaryContactEmailIsIM { get; set; }
        public string InvoiceAddressDescription { get; set; }
        public string HasSuframaDiscountPISandCOFINS { get; set; }
        public string AddressLocationId { get; set; }
        public int WarehouseFulfillmentRate { get; set; }
        public string FederalComments { get; set; }
        public int InvoiceAddressLatitude { get; set; }
        public string CustomerPaymentFinancialInterestCode { get; set; }
        public string PrimaryContactTelexDescription { get; set; }
        public string SalesCurrencyCode { get; set; }
        public string BrazilianCCM { get; set; }
        public DateTime InvoiceAddressValidFrom { get; set; }
        public string IsICMSContributor { get; set; }
        public string PaymentSchedule { get; set; }
        public string LineOfBusinessId { get; set; }
        public string CreditCardAddressVerificationLevel { get; set; }
        public string PaymentTerms { get; set; }
        public string ItemCustomerGroupId { get; set; }
        public string IsOneTimeCustomer { get; set; }
        public string PrimaryContactURL { get; set; }
        public string SalesOrderPoolId { get; set; }
        public string DeliveryAddressCountryRegionId { get; set; }
        public string IsTransactionPostedAsShipment { get; set; }
        public string TCSGroup { get; set; }
        public string PrimaryContactPhonePurpose { get; set; }
        public string PersonAnniversaryMonth { get; set; }
        public string CURPNumber { get; set; }
        public string OrderEntryDeadline { get; set; }
        public int DeliveryAddressLatitude { get; set; }
        public string DeliveryAddressCity { get; set; }
        public string PaymentCashDiscount { get; set; }
        public string PrimaryContactFax { get; set; }
        public DateTime DeliveryAddressValidFrom { get; set; }
        public string AddressStreet { get; set; }
        public string ResidenceForeignCountryRegionId { get; set; }
        public string InvoiceAddressCounty { get; set; }
        public string SuframaNumber { get; set; }
        public string PersonGender { get; set; }
        public string DeliveryMode { get; set; }
        public string IsRFIDCaseTaggingEnabled { get; set; }
        public string PrimaryContactPhoneIsMobile { get; set; }
        public DateTime InvoiceAddressValidTo { get; set; }
        public DateTime AddressValidTo { get; set; }
        public string DeliveryAddressDistrictName { get; set; }
        public string DefaultInventoryStatusId { get; set; }
        public string PaymentDay { get; set; }
        public string RFCNumber { get; set; }
        public string DeliveryAddressZipCode { get; set; }
        public string DestinationCode { get; set; }
        public string PrimaryContactTelex { get; set; }
        public string GiroTypeFreeTextInvoice { get; set; }
        public string CreditCardAddressVerificationIsAuthorizationVoidedOnFailure { get; set; }
        public string PersonInitials { get; set; }
        public string PersonMaritalStatus { get; set; }
        public string IsSalesTaxIncludedInPrices { get; set; }
        public string LanguageId { get; set; }
        public string ForeignerId { get; set; }
        public object AddressTimeZone { get; set; }
        public string PrimaryContactPhoneDescription { get; set; }
        public string IsRFIDItemTaggingEnabled { get; set; }
        public string AddressCountryRegionId { get; set; }
        public string IdentificationNumber { get; set; }
        public string ReceiptOption { get; set; }
        public string TransactionPresenceType { get; set; }
        public string SupplementaryItemGroupId { get; set; }
        public string CommissionCustomerGroupId { get; set; }
        public string GiroTypeCollectionletter { get; set; }
        public string WarehouseIsEntireShipmentFilled { get; set; }
        public string CustomerTMAGroupId { get; set; }
        public string PrimaryContactLinkedInPurpose { get; set; }
        public string InvoiceAddressCountryRegionId { get; set; }
        public string ForeignCustomer { get; set; }
        public string FiscalCode { get; set; }
        public DateTime DeliveryAddressValidTo { get; set; }
        public string GiroTypeAccountStatement { get; set; }
        public string PrimaryContactTwitterPurpose { get; set; }
        public string OrganizationABCCode { get; set; }
        public int CreditLimit { get; set; }
        public string WarehouseFulfillmentType { get; set; }
        public int OrganizationNumberOfEmployees { get; set; }
        public string PaymentUseCashDiscount { get; set; }
        public string CreditLimitIsMandatory { get; set; }
        public string ElectronicInvoiceEAN { get; set; }
        public string ExportSale { get; set; }
        public string IsExcludedFromInterestChargeCalculation { get; set; }
        public string PrimaryContactFacebookDescription { get; set; }
        public string TaxExemptNumber { get; set; }
        public string WriteoffReason { get; set; }
        public string BrazilianINSSCEI { get; set; }
        public string IsFreightAccrued { get; set; }
        public string PrimaryContactFaxExtension { get; set; }
        public string PersonChildrenNames { get; set; }
        public string IsExternallyMaintained { get; set; }
        public string AddressCountryRegionISOCode { get; set; }
        public string PackingMaterialFeeLicenseNumber { get; set; }
        public string IsExpressBillOfLadingAccepted { get; set; }
        public string PartyType { get; set; }
        public string DeliveryAddressCountryRegionISOCode { get; set; }
        public string TaxRegistrationId { get; set; }
        public string PersonPhoneticFirstName { get; set; }
        public int PersonAnniversaryYear { get; set; }
        public string PrimaryContactTwitterDescription { get; set; }
        public string InvoiceAddressCountryRegionISOCode { get; set; }
        public string TDSGroup { get; set; }
        public string PersonProfessionalSuffix { get; set; }
        public string PreferentialCustomer { get; set; }
        public string NatureOfAssessee { get; set; }
        public string PrimaryContactLinkedInDescription { get; set; }
        public string NAFCode { get; set; }
        public string DeliveryAddressLocationId { get; set; }
        public string PrimaryContactEmailPurpose { get; set; }
        public string FullPrimaryAddress { get; set; }
        public string CompanyChain { get; set; }
        public DateTime AddressValidFrom { get; set; }
        public string PrimaryContactURLPurpose { get; set; }
        public string CustomerGroupId { get; set; }
        public string DeliveryAddressCounty { get; set; }
        public string MultiLineDiscountCode { get; set; }
        public string ReceiptEmail { get; set; }
        public string PersonHobbies { get; set; }
        public string CreditCardCVC { get; set; }
        public string AddressDistrictName { get; set; }
        public string AddressBrazilianCNPJOrCPF { get; set; }
        public string AddressLocationRoles { get; set; }
        public string DeliveryAddressStreet { get; set; }
        public string CentralBankPurposeNotes { get; set; }
        public string DiscountPriceGroupId { get; set; }
        public string NationalRegistryNumber { get; set; }
        public string CollectionsContactPersonId { get; set; }
        public string PartyNumber { get; set; }
        public string InvoiceAddress { get; set; }
        public string WarehouseIsASNGenerated { get; set; }
        public string FederalAgencyLocationCode { get; set; }
        public string CompanyType { get; set; }
        public int InvoiceAddressLongitude { get; set; }
        public string Name { get; set; }
        public string ReliefGroupId { get; set; }
        public string FrenchSiret { get; set; }
        public string PrimaryContactTelexPurpose { get; set; }
        public string FulfillmentErrorTolerance { get; set; }
        public string ReceiptCalendar { get; set; }
        public string InvoiceAddressCity { get; set; }
        public string SalesReturnTaxGroup { get; set; }
        public string SalesMemo { get; set; }
        public string IsFinalUser { get; set; }
        public string EmployeeResponsibleNumber { get; set; }
        public string PrimaryContactFaxDescription { get; set; }
        public string PrimaryContactLinkedIn { get; set; }
        public string BrazilianCNAE { get; set; }
        public string ContactPersonId { get; set; }
        public string CreditRating { get; set; }
        public string PrimaryContactFacebook { get; set; }
        public string PaymentBankAccount { get; set; }
        public string ChargesGroupId { get; set; }
        public string OnHoldStatus { get; set; }
        public string EnterpriseNumber { get; set; }
        public string GiroTypeProjInvoice { get; set; }
        public string InvoiceAddressDistrictName { get; set; }
        public string NameAlias { get; set; }
        public string VendorAccount { get; set; }
        public string IsRFIDPalletTaggingEnabled { get; set; }
        public string OrganizationPhoneticName { get; set; }
        public string PANNumber { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string IsElectronicInvoice { get; set; }
        public int DeliveryAddressLongitude { get; set; }
        public string SalesDistrict { get; set; }
        public string PrimaryContactEmailDescription { get; set; }
        public string IsInSuframaRegion { get; set; }
        public string BirthPlace { get; set; }
        public string DeliveryAddressState { get; set; }
        public string SalesAccountNumber { get; set; }
        public string InvoiceAddressZipCode { get; set; }
        public object DeliveryAddressTimeZone { get; set; }
        public string BirthCountyCode { get; set; }
        public string DefaultDimensionDisplayValue { get; set; }
        public string SalesTaxGroup { get; set; }
        public string TotalDiscountCode { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string PaymentFactoringAccount { get; set; }
        public int AddressLongitude { get; set; }
        public string CentralBankPurposeCode { get; set; }
        public string OrganizationNumber { get; set; }
        public string BrazilianIE { get; set; }
        public object InvoiceAddressTimeZone { get; set; }
        public string FederalIndicator { get; set; }
        public string PrimaryContactTwitter { get; set; }
        public string PanStatus { get; set; }
        public string PersonPhoneticMiddleName { get; set; }
        public string PackingDutyLicense { get; set; }
        public string DeliveryReason { get; set; }
        public string CalculateWithholdingTax { get; set; }
        public string PrimaryContactFacebookPurpose { get; set; }
        public string StateInscription { get; set; }
        public string StatisticsGroupId { get; set; }
        public string SalesSubsegmentId { get; set; }
        public int PaymentTermsBaseDays { get; set; }
        public string CustomerPaymentFineCode { get; set; }
        public string PrimaryContactFaxPurpose { get; set; }
        public string KnownAs { get; set; }
        public string IsFuelSurchargeApplied { get; set; }
        public string BrazilianCNPJOrCPF { get; set; }
        public string CustomerWithholdingContributionType { get; set; }
        public string CommissionSalesGroupId { get; set; }
        public string BrazilianNIT { get; set; }
        public string InvoiceAddressState { get; set; }
        public string SalesSegmentId { get; set; }
        public string IsWithholdingTaxCalculated { get; set; }
        public string PersonPhoneticLastName { get; set; }
        public string IsServiceDeliveryAddressBased { get; set; }
        public string PartyCountry { get; set; }
        public string GiroTypeInterestNote { get; set; }
        public string PaymentSpecification { get; set; }
        public string WithholdingTaxGroupCode { get; set; }
        public int ConsolidationDay { get; set; }
        public string DeliveryTerms { get; set; }
        public string AccountStatement { get; set; }
        public string ElectronicLocationId { get; set; }
        public string PaymentIdType { get; set; }
    }
}