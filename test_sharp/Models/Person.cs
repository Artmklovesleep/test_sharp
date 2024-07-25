using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace test_sharp.Models
{
    [XmlRoot("FLInfo")]
    public class Person : BaseViewModel
    {
        private string _lastName;
        [XmlElement("Family")]
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string _firstName;
        [XmlElement("Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _middleName;
        [XmlElement("Patronymic")]
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged(nameof(MiddleName));
                }
            }
        }

        private PersonalInformation _personalInformation;
        [XmlElement("PersonalInformation")]
        public PersonalInformation PersonalInfo
        {
            get => _personalInformation;
            set
            {
                if (_personalInformation != value)
                {
                    _personalInformation = value;
                    OnPropertyChanged(nameof(PersonalInfo));
                }
            }
        }

        private DetailsOfDocument _detailsOfDocument;
        [XmlElement("DetailsOfDocument")]
        public DetailsOfDocument DocumentDetails
        {
            get => _detailsOfDocument;
            set
            {
                if (_detailsOfDocument != value)
                {
                    _detailsOfDocument = value;
                    OnPropertyChanged(nameof(DocumentDetails));
                }
            }
        }

        public Person()
        {
            PersonalInfo = new PersonalInformation();
            DocumentDetails = new DetailsOfDocument();
        }

        public void Clear()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            PersonalInfo.Clear();
            DocumentDetails.Clear();
        }

        public bool ValidateName()
        {
            var regexRule = new RegexValidationRule();
            var RegexPattern = @"^(?:[A-Za-z]{1,20}|[а-яА-Я]{1,20})$";

            return regexRule.Validate(RegexPattern, FirstName, 20) && regexRule.Validate(RegexPattern, LastName, 20) && regexRule.Validate(RegexPattern, MiddleName, 20);
        }
    }

    public class PersonalInformation : BaseViewModel
    {
        private string _snils;
        [XmlElement("SNILS")]
        public string Snils
        {
            get => _snils;
            set
            {
                if (_snils != value)
                {
                    _snils = value;
                    OnPropertyChanged(nameof(Snils));
                }
            }
        }

        private string _adress;
        [XmlElement("LocationInfo")]
        public string Adress
        {
            get => _adress;
            set
            {
                if (_adress != value)
                {
                    _adress = value;
                    OnPropertyChanged(nameof(Adress));
                }
            }
        }

        private string _inn;
        [XmlElement("INN")]
        public string Inn
        {
            get => _inn;
            set
            {
                if (_inn != value)
                {
                    _inn = value;
                    OnPropertyChanged(nameof(Inn));
                }
            }
        }

        private string _ogrnip;
        [XmlElement("OGRNIP")]
        public string Ogrnip
        {
            get => _ogrnip;
            set
            {
                if (_ogrnip != value)
                {
                    _ogrnip = value;
                    OnPropertyChanged(nameof(Ogrnip));
                }
            }
        }

        [XmlIgnore]
        public bool HasErrors { get; set; }

        public void Clear()
        {
            Snils = string.Empty;
            Adress = string.Empty;
            Inn = string.Empty;
            Ogrnip = string.Empty;
        }

        public bool ShouldSerialize()
        {
            return !string.IsNullOrEmpty(Snils) &&
                   !string.IsNullOrEmpty(Adress) &&
                   !string.IsNullOrEmpty(Inn) &&
                   !string.IsNullOrEmpty(Ogrnip);
        }

        public bool ValidatePersonalInfo()
        {
            var snilsPattern = @"^\d{3}-\d{3}-\d{3} \d{2}$";
            var innPattern = @"^(?:[a-zA-Z]{1,15}|[а-яА-Я]{1,15})$";
            var ogrnipPattern = "";
            var addressPattern = "";

            var regexRule = new RegexValidationRule();

            return regexRule.Validate(snilsPattern, Snils, 15, false ) &&
                   regexRule.Validate(innPattern, Inn, 15, false) &&
                   regexRule.Validate(ogrnipPattern, Ogrnip, 15, false) &&
                   regexRule.Validate(addressPattern, Adress, 100, false);
        }
    }

    public class DetailsOfDocument : BaseViewModel
    {
        private string _codeDocument;
        [XmlElement("CodeDocument")]
        public string CodeDocument
        {
            get => _codeDocument;
            set
            {
                if (_codeDocument != value)
                {
                    _codeDocument = value;
                    OnPropertyChanged(nameof(CodeDocument));
                }
            }
        }

        private string _nameDocument;
        [XmlElement("NameDocument")]
        public string NameDocument
        {
            get => _nameDocument;
            set
            {
                if (_nameDocument != value)
                {
                    _nameDocument = value;
                    OnPropertyChanged(nameof(NameDocument));
                }
            }
        }

        private string _seriesDocument;
        [XmlElement("Series")]
        public string SeriesDocument
        {
            get => _seriesDocument;
            set
            {
                if (_seriesDocument != value)
                {
                    _seriesDocument = value;
                    OnPropertyChanged(nameof(SeriesDocument));
                }
            }
        }

        private string _numberDocument;
        [XmlElement("Number")]
        public string NumberDocument
        {
            get => _numberDocument;
            set
            {
                if (_numberDocument != value)
                {
                    _numberDocument = value;
                    OnPropertyChanged(nameof(NumberDocument));
                }
            }
        }

        private string _issuanceDate;
        [XmlElement("IssuanceDate")]
        public string IssuanceDate
        {
            get => _issuanceDate;
            set
            {
                if (_issuanceDate != value)
                {
                    _issuanceDate = value;
                    OnPropertyChanged(nameof(IssuanceDate));
                }
            }
        }

        private string _documentAuthor;
        [XmlElement("DocumentAuthor")]
        public string DocumentAuthor
        {
            get => _documentAuthor;
            set
            {
                if (_documentAuthor != value)
                {
                    _documentAuthor = value;
                    OnPropertyChanged(nameof(DocumentAuthor));
                }
            }
        }

        [XmlIgnore]
        public bool HasErrors { get; set; }

        public void Clear()
        {
            CodeDocument = string.Empty;
            NameDocument = string.Empty;
            SeriesDocument = string.Empty;
            NumberDocument = string.Empty;
            IssuanceDate = string.Empty;
            DocumentAuthor = string.Empty;
        }

        public bool ShouldSerialize()
        {
            return !string.IsNullOrEmpty(CodeDocument) &&
                   !string.IsNullOrEmpty(NameDocument) &&
                   !string.IsNullOrEmpty(SeriesDocument) &&
                   !string.IsNullOrEmpty(NumberDocument) &&
                   !string.IsNullOrEmpty(IssuanceDate) &&
                   !string.IsNullOrEmpty(DocumentAuthor);
        }

        public bool ValidateDocumentDetails()
        {
            var codePattern = @"^\d{12}$";
            var namePattern = "";
            var seriesPattern = @"^\S{10}$"; 
            var numberPattern = @"^\S{10}$"; 
            var datePattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d{2}$"; 
            var authorPattern = ""; 


            var regexRule = new RegexValidationRule();

            return regexRule.Validate(codePattern, CodeDocument, 12, false) &&
                   regexRule.Validate(namePattern, NameDocument, 100, false) &&
                   regexRule.Validate(seriesPattern, SeriesDocument, 10, false) &&
                   regexRule.Validate(numberPattern, NumberDocument, 10, false) &&
                   regexRule.Validate(datePattern, IssuanceDate, 10, false) &&
                   regexRule.Validate(authorPattern, DocumentAuthor, 50, false);
        }
    }
}

