import * as React from 'react';
import Typography from '@mui/material/Typography';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Grid from '@mui/material/Grid';
import { SubscriptionPlan } from '../Membership/Membership';
import { useEffect } from 'react';

const payments = [
  { name: 'Card type', detail: 'Visa' },
  { name: 'Card number', detail: 'xxxx-xxxx-xxxx-4242' },
  { name: 'Expiry date', detail: '08/2024' },
];

export default function Review(subscriptionPlan: SubscriptionPlan) {
    useEffect(() => {
        console.log(subscriptionPlan);
    }, [subscriptionPlan])
  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Order summary
      </Typography>
      <List disablePadding>
        <ListItem sx={{ py: 1, px: 0 }}>
            <ListItemText primary={subscriptionPlan.name} secondary={subscriptionPlan.description} />
            <Typography variant="body2" style={{fontWeight: '700'}}>${subscriptionPlan.price/100}</Typography>
        </ListItem>
        <ListItem sx={{ py: 1, px: 0 }}>
          <ListItemText primary="Total" />
          <Typography variant="subtitle1" sx={{ fontWeight: 700 }}>
            ${subscriptionPlan.price/100}
          </Typography>
        </ListItem>
      </List>
      <Grid container spacing={2}>
        <Grid item container direction="column" xs={12} sm={6}>
          <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
            Payment details
          </Typography>
          <Grid container>
            {payments.map((payment) => (
              <React.Fragment key={payment.name}>
                <Grid item xs={6}>
                  <Typography gutterBottom>{payment.name}</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography gutterBottom>{payment.detail}</Typography>
                </Grid>
              </React.Fragment>
            ))}
          </Grid>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}