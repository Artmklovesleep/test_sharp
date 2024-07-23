using System;

namespace test_sharp.Models
{
    public class Document : BaseViewModel
    {
        private int _codeDocument;
        public int CodeDocument
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

        private DateTime _issuanceDate;
        public DateTime IssuanceDate
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

        private string _issuingOrganization;
        public string IssuingOrganization
        {
            get => _issuingOrganization;
            set
            {
                if (_issuingOrganization != value)
                {
                    _issuingOrganization = value;
                    OnPropertyChanged(nameof(IssuingOrganization));
                }
            }
        }

        private string _documentAuthor;
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
    }
}
