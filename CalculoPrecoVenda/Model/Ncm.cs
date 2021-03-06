﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

namespace CalculoPrecoVenda.Model
{
    public class Ncm : INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        List<string> listError = new List<string>();

        private int ncmId;
        private string codNcm;
        private string nomeNCm;
        private double? impImportacao;
        private double? ipi;
        private double? mva;
        private int? autopecas;
        private int? semSimilar;
        private string cest;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public int NcmId
        {
            get { return ncmId; }
            set { ncmId = value; }
        }

        public string CodNcm
        {
            get { return codNcm; }
            set
            {
                codNcm = value;

                if (string.IsNullOrEmpty(codNcm) || codNcm.Length < 8)
                {
                    listError.Add("O código da NCM deve conter 8 digitos!");
                    AddErrors("CodNcm", listError);
                }
                else
                {
                    CleanErrors("CodNcm");
                }
            }
        }
        public string NomeNcm
        {
            get { return nomeNCm; }
            set
            {
                nomeNCm = value;
                if (string.IsNullOrEmpty(nomeNCm))
                {
                    listError.Add("A descrição da NCM não pode ficar em branco");
                    AddErrors("NomeNcm", listError);
                }
                else
                {
                    CleanErrors("NomeNcm");
                }
                
            }
        }
        
        public double? ImpImportacao
        {
            get { return impImportacao; }
            set { impImportacao = value; }
        }
        
        public double? Ipi
        {
            get { return ipi; }
            set { ipi = value; }
        }

        public double? Mva
        {
            get { return mva; }
            set { mva = value; }
        }

        public int? Autopecas
        {
            get { return autopecas; }
            set { autopecas = value; }
        }

        public int? SemSimilar
        {
            get { return semSimilar; }
            set { semSimilar= value; }
        }

        public string Cest
        {
            get { return cest; }
            set { cest = value; }
        }

        public bool HasErrors
        {
            get
            {
                return errors.Count > 0;
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values;
            }
            else
            {
                List<string> propertyErrors;
                errors.TryGetValue(propertyName, out propertyErrors);
                return propertyErrors;
            }
        }

        private void AddErrors(string propertyName, List<string> propertyErrors)
        {
            errors[propertyName] = propertyErrors;

            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void CleanErrors(string propertyName)
        {
            errors.Remove(propertyName);

            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
