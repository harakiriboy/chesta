import React, { useEffect, useState } from 'react'
import agent from '../services/agent';
import LoadingComponent from '../layouts/Loading/LoadingComponent';

function PayoutsPage() {
  const [subscriptions, setSubscriptions] = useState([
    {id: 1, stripeSubscriptionId: "some string1"},
    {id: 2, stripeSubscriptionId: "some string2"}
  ]);

  const [loading, setLoading] = useState(true);
  
  useEffect(() => {
    agent.Subscription.list()
      .then(response => setSubscriptions(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, []);

  if(loading) return <LoadingComponent message='Loading subscriptions' />

  return (
    <div>
      <h1>PayoutsPage</h1>
      <ul>
        {subscriptions.map((item, index) => (
          <li key={index}>{item.id} - {item.stripeSubscriptionId}</li>
        ))}
      </ul>
    </div>
  )
}

export default PayoutsPage