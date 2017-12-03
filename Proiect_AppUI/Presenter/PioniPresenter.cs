using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Proiect_AppUI.Model;
using Proiect_AppUI.Properties;

namespace Proiect_AppUI.Presenter
{
    public class PioniPresenter
    {
        private List<Jucator> _jucatori;
        private readonly Zar _zar;

        //private IJocView view k instead of JocForm
        private readonly JocForm _view;

        private int _randJucator;
        private int _valoareZar;
        private bool _aFacutMutarea;

        public PioniPresenter(JocForm view)
        {
            _view = view;
            _view.Presenter = this;

            InitializeazaJucatori(_view.NumarJucatori);
            InitializeazaVariabileJoc();
            _zar = new Zar();
        }

        private void InitializeazaJucatori(int numarJucatori)
        {
            _jucatori = new List<Jucator>(numarJucatori);
            for (var i = 0; i < numarJucatori; i++)
            {
                _jucatori.Add(new Jucator(i, GetNumeJucator(i), (Culoare) i, GetCasuteStartPentru((Culoare) i)));
                _jucatori[i].InitializeazaPioni();
            }
        }

        private void InitializeazaVariabileJoc()
        {
            _randJucator = 0;
            _valoareZar = 0;
            _aFacutMutarea = false;
        }

        public void IncearcaSaDemarcheziUrmatoareaPozitie(Casuta.UserControl.Casuta casuta)
        {
            if (_aFacutMutarea || _view.valoareZarPctrBox.BackgroundImage == Resources.info)
                return;

            var pion = GetPionDinCasuta(casuta);
            if (pion == null || !_jucatori[_randJucator].Pioni.Contains(pion))
            {
                return;
            }

            var umatoareaPozitie = GetUrmatoareaPozitiePion(pion);
            if (umatoareaPozitie < 0 || umatoareaPozitie > Constants.Constants.UltimaPozitie)
                return;

            var casutaUrmatoarePozitie = GetCasutaDePePozitia(umatoareaPozitie);

            casutaUrmatoarePozitie.ImaginePion.Image = null;
        }

        public void IncearcaSaMarcheziUrmatoareaPozitie(Casuta.UserControl.Casuta casuta)
        {
            if (_aFacutMutarea || _view.valoareZarPctrBox.BackgroundImage == Resources.info)
                return;

            var pion = GetPionDinCasuta(casuta);
            if (pion == null || !_jucatori[_randJucator].Pioni.Contains(pion))
            {
                return;
            }

            var umatoareaPozitie = GetUrmatoareaPozitiePion(pion);
            if (umatoareaPozitie < 0 || umatoareaPozitie > Constants.Constants.UltimaPozitie)
                return;

            var casutaUrmatoarePozitie = GetCasutaDePePozitia(umatoareaPozitie);
            if (casutaUrmatoarePozitie.EsteOcupata)
            {
                var pionUrmatoareaPozitie = GetPionDinCasuta(casutaUrmatoarePozitie);
                //In acea casuta este un pion de-al tau
                if (_jucatori[_randJucator].Pioni.Contains(pionUrmatoareaPozitie))
                {
                    return;
                }
            }

            casutaUrmatoarePozitie.ImaginePion.Image = Resources.x;
        }

        public void IncearcaSaMutiPionDin(Casuta.UserControl.Casuta casuta)
        {
            if (!casuta.EsteOcupata)
                return;

            if (_aFacutMutarea)
            {
                MessageBox.Show("Ai mutat deja");
                return;
            }
            var pion = GetPionDinCasuta(casuta);
            if (pion == null)
            {
                MessageBox.Show("Nu ai pion in acea casuta");
                return;
            }
            
            var umatoareaPozitie = GetUrmatoareaPozitiePion(pion);

            //Nu a dat 6 ca sa iasa
            if (umatoareaPozitie < 0)
            {
                MessageBox.Show("Trebuie sa dai 6 sa iesi");
                return;
            }

            if (umatoareaPozitie > Constants.Constants.UltimaPozitie)
            {
                MessageBox.Show("Nu mai poti muta pionul");
                return;
            }

            var casutaUrmatoarePozitie = GetCasutaDePePozitia(umatoareaPozitie);
            IncearcaSaDemarcheziUrmatoareaPozitie(casuta);
            IncearcaSaMutiPionIn(casutaUrmatoarePozitie, pion);

            VerificaDacaACastigat();
        }

        private void VerificaDacaACastigat()
        {
            int sumaPozitiiPioni = 0;
            foreach (var pion in _jucatori[_randJucator].Pioni)
            {
                sumaPozitiiPioni += pion.PozitiaCurenta;
            }

            if (sumaPozitiiPioni == Constants.Constants.SumaFinalaPozitiiPioni)
            {
                //add button for play again and quit
                MessageBox.Show($"Felicitari {_jucatori[_randJucator].Nume}, ai castigat!");
                _view.terminaTuraBtn.Enabled = false;
                _view.aruncaZarulBtn.Enabled = false;
            }
        }

        private void IncearcaSaMutiPionIn(Casuta.UserControl.Casuta casuta, Pion pion)
        {
            if (casuta.EsteOcupata)
            {
                var pionUrmatoareaPozitie = GetPionDinCasuta(casuta);

                if (pion.Imagine.Equals(pionUrmatoareaPozitie.Imagine))
                {
                    MessageBox.Show("In acea casuta este un pion de-al tau");
                    return;
                }

                MutaPionInCasa(pionUrmatoareaPozitie);
            }

            MutaPionInCasuta(pion, casuta, GetUrmatoareaPozitiePion(pion));
        }

        private void ElibereazaCasuta(Casuta.UserControl.Casuta casuta)
        {
            casuta.ImaginePion.BackgroundImage = null;
            casuta.EsteOcupata = false;
        }

        private void MutaPionInCasuta(Pion pion, Casuta.UserControl.Casuta casuta, int pozitieCasuta)
        {
            ElibereazaCasuta(pion.CasutaCurenta);

            pion.CasutaCurenta = casuta;
            pion.CasutaCurenta.EsteOcupata = true;
            pion.PozitiaCurenta = pozitieCasuta;
            casuta.ImaginePion.BackgroundImage = pion.Imagine;
            _aFacutMutarea = true;
        }

        private void MutaPionInCasa(Pion pion)
        {
            pion.CasutaCurenta = pion.Acasa;
            pion.CasutaCurenta.EsteOcupata = true;
            pion.CasutaCurenta.ImaginePion.BackgroundImage = pion.Imagine;
        }

        private Pion GetPionDinCasuta(Casuta.UserControl.Casuta casuta)
        {
            foreach (var jucator in _jucatori)
            {
                foreach (var pion in jucator.Pioni)
                {
                    if (pion.CasutaCurenta.Equals(casuta))
                        return pion;
                }
            }
            //throw new PionNotFound;
            return null;
        }

        private Casuta.UserControl.Casuta GetCasutaDePePozitia(int pozitie)
        {
            switch (_randJucator)
            {
                case 0:
                    return GetCasutaJucatorRosuDePePozitia(pozitie);
                case 1:
                    return GetCasutaJucatorVerdeDePePozitia(pozitie);
                case 2:
                    return GetCasutaJucatorAlbastruDePePozitia(pozitie);
                case 3:
                    return GetCasutaJucatorGalbenDePePozitia(pozitie);
            }
            //throw new InvalidJucator;
            return null;
        }

        private Casuta.UserControl.Casuta GetCasutaJucatorRosuDePePozitia(int pozitie)
        {
            foreach (var casuta in _view.Casute)
            {
                if (casuta.PozitieRosu == pozitie)
                    return casuta;
            }
            //throw new PozitieCasutaInvalida;
            return null;
        }

        private Casuta.UserControl.Casuta GetCasutaJucatorVerdeDePePozitia(int pozitie)
        {
            foreach (var casuta in _view.Casute)
            {
                if (casuta.PozitieVerde == pozitie)
                    return casuta;
            }
            //throw new PozitieCasutaInvalida;
            return null;
        }

        private Casuta.UserControl.Casuta GetCasutaJucatorAlbastruDePePozitia(int pozitie)
        {
            foreach (var casuta in _view.Casute)
            {
                if (casuta.PozitieAlbastru == pozitie)
                    return casuta;
            }
            //throw new PozitieCasutaInvalida;
            return null;
        }

        private Casuta.UserControl.Casuta GetCasutaJucatorGalbenDePePozitia(int pozitie)
        {
            foreach (var casuta in _view.Casute)
            {
                if (casuta.PozitieGalben == pozitie)
                    return casuta;
            }
            //throw new PozitieCasutaInvalida;
            return null;
        }

        private int GetPozitieCurentaPion(Pion pion)
        {
            switch (_randJucator)
            {
                case 0:
                    return pion.CasutaCurenta.PozitieRosu;

                case 1:
                    return pion.CasutaCurenta.PozitieVerde;

                case 2:
                    return pion.CasutaCurenta.PozitieAlbastru;

                case 3:
                    return pion.CasutaCurenta.PozitieGalben;
            }
            //throw new InvalidRandJucator;
            return 0;
        }

        private int GetUrmatoareaPozitiePion(Pion pion)
        {
            return GetPozitieCurentaPion(pion) + _valoareZar;
        }

        //Vezi comm
        public void ZarAruncat()
        {
//            Add method to check if player has at least one possible move
//            if (_view.aruncaZarulBtn.Enabled && _valoareZar == Constants.Constants.ValoareMagicaZar && !_aFacutMutarea)
//            {
//                MessageBox.Show("Muta mai intai pionul");
//                return;
//            }

            _valoareZar = _zar.AruncaZar;
            Console.WriteLine($"Valoare zar: {_valoareZar}");

            switch (_valoareZar)
            {
                case 1:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.one;
                    break;
                case 2:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.two;
                    break;
                case 3:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.three;
                    break;
                case 4:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.four;
                    break;
                case 5:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.five;
                    break;
                case 6:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.six;
                    break;
                default:
                    _view.valoareZarPctrBox.BackgroundImage = Resources.info;
                    break;
            }

            if (_valoareZar != Constants.Constants.ValoareMagicaZar)
            {
                _view.aruncaZarulBtn.Enabled = false;
                _view.terminaTuraBtn.Enabled = true;
            }
            _aFacutMutarea = false;
        }

        public void UrmatorulJucator()
        {
            _view.valoareZarPctrBox.BackgroundImage = Resources.info;

            _randJucator++;
            _randJucator %= _view.NumarJucatori;

            _view.aruncaZarulBtn.Enabled = true;
            _view.terminaTuraBtn.Enabled = false;

            switch (_randJucator)
            {
                case 0:
                    _view.jucatorCurentPctrBox.BackgroundImage = Resources.red;
                    break;
                case 1:
                    _view.jucatorCurentPctrBox.BackgroundImage = Resources.green;
                    break;
                case 2:
                    _view.jucatorCurentPctrBox.BackgroundImage = Resources.blue;
                    break;
                case 3:
                    _view.jucatorCurentPctrBox.BackgroundImage = Resources.yellow;
                    break;
            }
        }

        private string GetNumeJucator(int index)
        {
            return _view.NumeJucatori[index];
        }

        private List<Casuta.UserControl.Casuta> GetCasuteStartPentru(Culoare culoareJucator)
        {
            List<Casuta.UserControl.Casuta> casuteStart =
                new List<Casuta.UserControl.Casuta>(Constants.Constants.NumarPioni);

            switch (culoareJucator)
            {
                case Culoare.Rosu:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieRosu == Constants.Constants.PozitieAcasa && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Verde:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieVerde == Constants.Constants.PozitieAcasa && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Albastru:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieAlbastru == Constants.Constants.PozitieAcasa && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Galben:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieGalben == Constants.Constants.PozitieAcasa && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
            }
            //throw new InvalidColor;
            return null;
        }
    }
}