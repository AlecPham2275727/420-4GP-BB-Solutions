using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementSquelette : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsPatrouille;
    private NavMeshAgent _agent;
    private int _indexPatrouille;
    private Animator _animator;

    private EtatSquelette _etat;

    public EtatPatrouille Patrouille
    {
        private set;
        get;
    }

    public EtatPoursuite Poursuite
    {
        private set;
        get;
    }

    public EtatAttente Attente
    {
        private set;
        get;
    }

    public EtatMort Mort
    {
        private set;
        get;
    }

    public bool EstMort
    {
        get
        {
            return _etat == Mort;
        }
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _indexPatrouille = 0;
        _agent.destination = _pointsPatrouille[_indexPatrouille].position;
        _animator = GetComponent<Animator>();
        GameObject joueur = GameObject.Find("Joueur");
        Patrouille = new EtatPatrouille(this, joueur, _pointsPatrouille);
        Poursuite = new EtatPoursuite(this, joueur);
        Attente = new EtatAttente(this, joueur);
        Mort = new EtatMort(this, null);

        _etat = Patrouille;
        _etat.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        _etat.Handle(Time.deltaTime);
    }

    public void ChangerEtat(EtatSquelette nouvelEtat)
    {
        _etat.Leave();
        _etat = nouvelEtat;
        _etat.Enter();
    }

}