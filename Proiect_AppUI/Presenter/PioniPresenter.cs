using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Proiect_AppUI.Model;
using Proiect_AppUI.Properties;

namespace Proiect_AppUI.Presenter
{
    public class PioniPresenter
    {
        //private IJocView view k instead of JocForm
        private readonly JocForm _view;

        private List<Jucator> _jucatori;
        private readonly Zar _zar;
        private int _randJucator;
        private int _valoareZar;
        private bool _aFacutMutarea;
        private readonly SoundPlayer _soundPlayer;

        public PioniPresenter(JocForm view)
        {
            _view = view;
            _view.Presenter = this;

            InitializeazaJucatori(_view.NumarJucatori);
            InitializeazaVariabileJoc();
            _zar = new Zar();
            _soundPlayer = new SoundPlayer();
            EfectSunet(Resources.start_game);
        }

        private void EfectSunet(UnmanagedMemoryStream numeFisier)
        {
            _soundPlayer.Stream = numeFisier;
            _soundPlayer.Play();
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
            _view.TerminaTuraActivat = false;
        }

        public void IncearcaSaDemarcheziUrmatoareaPozitie(Casuta.UserControl.Casuta casuta)
        {
            if (_aFacutMutarea || _view.ImagineValoareZar == Resources.info)
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
            if (_aFacutMutarea || _view.ImagineValoareZar == Resources.info)
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
            casutaUrmatoarePozitie.ImaginePion.Image = Resources.x;
        }

        public void IncearcaSaMutiPionDin(Casuta.UserControl.Casuta casuta)
        {
            if (!casuta.EsteOcupata)
                return;

            if (_aFacutMutarea)
            {
                MessageBox.Show(Resources.ai_mutat_deja_text, Resources.atentie_text);
                return;
            }
            var pion = GetPionDinCasuta(casuta);
            if (pion == null || !_jucatori[_randJucator].Pioni.Contains(pion))
            {
                MessageBox.Show(Resources.nu_ai_pion_in_acea_casuta_text, Resources.atentie_text);
                return;
            }

            var umatoareaPozitie = GetUrmatoareaPozitiePion(pion);

            //Nu a dat 6 ca sa iasa
            if (umatoareaPozitie < 0)
            {
                MessageBox.Show(Resources.arunca_6_sa_iesi_text, Resources.atentie_text);
                return;
            }

            if (umatoareaPozitie > Constants.Constants.UltimaPozitie)
            {
                MessageBox.Show(Resources.nu_mai_ai_unde_muta_pionul_text, Resources.atentie_text);
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
                _view.TerminaTuraActivat = false;
                _view.AruncaZarulActivat = false;

                EfectSunet(Resources.winner);

                var doresteJocNou = MessageBox.Show(
                    $"{string.Format(Resources.ai_castigat_text, GetNumeJucator(_randJucator))}\n{Resources.intreaba_joc_nou}",
                    Resources.titlu_felicitari, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                TerminaJoc(doresteJocNou);
            }
        }

        public void JocNou(DialogResult raspuns)
        {
            if (raspuns == DialogResult.Yes)
            {
                _view.JocNou = true;
                _view.Close();
            }
        }

        public void TerminaJoc(DialogResult raspuns)
        {
            if (raspuns == DialogResult.Yes)
            {
                _view.Close();
            }
        }

        private void IncearcaSaMutiPionIn(Casuta.UserControl.Casuta casuta, Pion pion)
        {
            if (casuta.EsteOcupata)
            {
                var pionUrmatoareaPozitie = GetPionDinCasuta(casuta);

                if (pion.Imagine.Equals(pionUrmatoareaPozitie.Imagine))
                {
                    MessageBox.Show(Resources.ai_deja_pion_in_acea_casuta_text, Resources.atentie_text);
                    return;
                }

                MutaPionInCasa(pionUrmatoareaPozitie);
                EfectSunet(Resources.go_home);
            }
            else
            {
                EfectSunet(Resources.move);
            }

            MutaPionInCasuta(pion, casuta, GetUrmatoareaPozitiePion(pion));

            _aFacutMutarea = true;
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
                    return GetCasutaJucatorGalbenDePePozitia(pozitie);
                case 3:
                    return GetCasutaJucatorAlbastruDePePozitia(pozitie);
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
                    return pion.CasutaCurenta.PozitieGalben;
                case 3:
                    return pion.CasutaCurenta.PozitieAlbastru;
            }
            //throw new InvalidRandJucator;
            return 0;
        }

        private int GetUrmatoareaPozitiePion(Pion pion)
        {
            return GetPozitieCurentaPion(pion) + _valoareZar;
        }

        public void ZarAruncat()
        {
            _valoareZar = _zar.AruncaZar;
            EfectSunet(Resources.roll_dice);

            switch (_valoareZar)
            {
                case 1:
                    _view.ImagineValoareZar = Resources.one;
                    break;
                case 2:
                    _view.ImagineValoareZar = Resources.two;
                    break;
                case 3:
                    _view.ImagineValoareZar = Resources.three;
                    break;
                case 4:
                    _view.ImagineValoareZar = Resources.four;
                    break;
                case 5:
                    _view.ImagineValoareZar = Resources.five;
                    break;
                case 6:
                    _view.ImagineValoareZar = Resources.six;
                    break;
                default:
                    _view.ImagineValoareZar = Resources.info;
                    break;
            }

            if (_valoareZar != Constants.Constants.ValoareMagicaZar)
            {
                _view.AruncaZarulActivat = false;
                _view.TerminaTuraActivat = true;
            }
            _aFacutMutarea = false;
        }

        public void UrmatorulJucator()
        {
            _view.ImagineValoareZar = Resources.info;

            _randJucator++;
            _randJucator %= _view.NumarJucatori;

            _view.AruncaZarulActivat = true;
            _view.TerminaTuraActivat = false;

            switch (_randJucator)
            {
                case 0:
                    _view.ImagineJucatorCurent = Resources.red;
                    break;
                case 1:
                    _view.ImagineJucatorCurent = Resources.green;
                    break;
                case 2:
                    _view.ImagineJucatorCurent = Resources.yellow;
                    break;
                case 3:
                    _view.ImagineJucatorCurent = Resources.blue;
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