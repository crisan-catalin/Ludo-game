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
        private Zar _zar;

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

        public void ZarAruncat()
        {
            if (_view.aruncaZarulBtn.Enabled && _valoareZar == 6 && !_aFacutMutarea)
                //Mesaj
                return;

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

            if (_valoareZar != 6)
            {
                _view.aruncaZarulBtn.Enabled = false;
                _view.terminaTuraBtn.Enabled = true;
                _aFacutMutarea = true;
            }
        }

        public void UrmatorulJucator()
        {
            _randJucator++;
            _randJucator %= _view.NumarJucatori;
            Console.WriteLine($"Jucatorul {_randJucator}");

            _view.aruncaZarulBtn.Enabled = true;
            _view.terminaTuraBtn.Enabled = false;
            _aFacutMutarea = false;

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

        //Remove mockup from method
        private List<Casuta.UserControl.Casuta> GetCasuteStartPentru(Culoare culoareJucator)
        {
            List<Casuta.UserControl.Casuta> casuteStart =
                new List<Casuta.UserControl.Casuta>(Constants.Constants.NumarPioni);

            //delete mock data
            casuteStart.Add(_view.Casute[0]);
            casuteStart.Add(_view.Casute[1]);
            casuteStart.Add(_view.Casute[2]);
            casuteStart.Add(_view.Casute[3]);
            return casuteStart;
            //

            switch (culoareJucator)
            {
                case Culoare.Rosu:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieRosu == Constants.Constants.PozitieStart && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Verde:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieVerde == Constants.Constants.PozitieStart && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Albastru:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieAlbastru == Constants.Constants.PozitieStart && !casuteStart.Contains(casuta))
                            casuteStart.Add(casuta);
                        if (casuteStart.Count == Constants.Constants.NumarPioni)
                            return casuteStart;
                    }
                    //throw new NotAllHomeCellsFound;
                    break;
                case Culoare.Galben:
                    foreach (var casuta in _view.Casute)
                    {
                        if (casuta.PozitieGalben == Constants.Constants.PozitieStart && !casuteStart.Contains(casuta))
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