using UnityEngine;

public class IceController : MonoBehaviour
{
    private bool visible = false;    // Da li je polje vidljivo?
    private bool available = false;    // Da li je polje dostupno za skok?

    private Animator animator;    // Referenca ka animator komponenti

    public void Show()    // Metoda pomoću koje se zahtijeva da polje postane vidljivo
    {
        visible = true;    // Postavi fleg za vidljivost
        animator.SetBool("Visible", true);    // Obavijesti Animator o promjeni vidljivosti
    }

    public void Hide()    // Metoda pomoću koje se zahtijeva da polje postane nevidljivo
    {
        visible = false;    // Postavi fleg za vidljivost
        available = false;    // Postavi fleg za dostupnost
        animator.SetBool("Visible", false);    // Obavijesti Animator o promjeni vidljivosti
    }

    public void SetAvailable(bool isAvailable)    // Metoda pomoću koje se setuje dostupnost polja
    {
        available = isAvailable;    // Postavi fleg za dostupnost
        animator.SetBool("Available", available);    // Obavijesti Animator o promjeni dostupnosti
    }

    public bool IsVisible()    // Metoda koja vraća vidljivost polja
    {
        return visible;
    }

    public bool IsAvailable()    // Metoda koja vraća dostupnost polja
    {
        return available;
    }

    void Awake()    // Inicijalizacija polja
    {
        animator = GetComponent<Animator>();    // Preuzimanje Animator komponente
    }
}
