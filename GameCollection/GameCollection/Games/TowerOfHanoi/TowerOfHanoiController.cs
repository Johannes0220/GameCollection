using System;
using System.Collections.Generic;
using System.Globalization;
using System.Globalization;

namespace GameCollection.Games.TowerOfHanoi;

public class TowerOfHanoiController :IPlayable
{
    private readonly TowerOfHanoi _towerOfHanoi;
    private readonly TowerOfHanoiView _towerOfHanoiView;

    public TowerOfHanoiController()
    {
        _towerOfHanoi=new TowerOfHanoi();
        _towerOfHanoiView=new TowerOfHanoiView();
    }
    public string GetName()
    {
        throw new NotImplementedException();
    }
    
    public void StartGame()
    {
        try
        {
            _towerOfHanoiView.DisplayRules();
            _towerOfHanoi.disks = _towerOfHanoiView.DisplayChooseDiskNumber();
            _towerOfHanoi.InitGame();

        Restart:
            
            
            while (!_towerOfHanoi.CheckWon())
            {
                _towerOfHanoiView.RenderTowers(_towerOfHanoi.stacks, _towerOfHanoi.disks,_towerOfHanoi.minimumNumberOfMoves,_towerOfHanoi.moves,_towerOfHanoi.state,_towerOfHanoi.source);
                int input=0;
                switch (_towerOfHanoi.state)
                {
                    case TowerOfHanoiGameState.ChooseSource:
                        input=_towerOfHanoiView.DisplayChooseSource();
                        break;
                    case TowerOfHanoiGameState.ChooseTarget:
                        input = _towerOfHanoiView.DisplayChooseTarget();
                        break;
                    case TowerOfHanoiGameState.InvalidTarget:
                        _towerOfHanoiView.DisplayInvalidTarget();
                        
                        break;
                }
                _towerOfHanoi.UpdateGameState(input);
            }
            
            _towerOfHanoiView.RenderTowers(_towerOfHanoi.stacks, _towerOfHanoi.disks, _towerOfHanoi.minimumNumberOfMoves, _towerOfHanoi.moves, _towerOfHanoi.state, _towerOfHanoi.source);
            _towerOfHanoiView.DisplayWon();
        }
        catch (Exception e)
        {

        }
        

        

        
        




    }
    
}