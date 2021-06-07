using System.Collections;

public abstract class State
{

    public IEnumerator Idle()
    {

        yield break;

    }

    public IEnumerator patrol()
    {

        yield break;

    }

    public IEnumerator Chase()
    {

        yield break;

    }

    public IEnumerator Attack()
    {

        yield break;
    }
}
