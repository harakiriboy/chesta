import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardHeader from '@mui/material/CardHeader';
import CssBaseline from '@mui/material/CssBaseline';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Link, useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';
import LoadingComponent from '../../layouts/Loading/LoadingComponent';
import agent from '../../services/agent';


export interface SubscriptionPlan {
  id: number;
  name: string;
  description: string;
  accessLevel: string;
  price: number;
}

function PricingContent() {
  const location = useLocation();
  
  const [subscriptionPlans, setSubscriptionPlans] = useState<SubscriptionPlan[]>();
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    location.pathname = location.pathname.substring(1);
        if(location.pathname.includes('membership')) {
            location.pathname = location.pathname.split('/')[0];
        }
    agent.Subscription.listPlans(location.pathname)
      .then(response => setSubscriptionPlans(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, [location])

  if(loading) return <LoadingComponent message='Loading subscription plans' />

  return (
    <>
    {(JSON.parse(localStorage.getItem('localUser')!).role === 'author' && localStorage.getItem('localAuthor') === location.pathname) ? (
      <React.Fragment>
      <CssBaseline />
      <Container maxWidth="md" component="main">
        <Grid container spacing={5} direction={'column'} item xs={9} sx={{m: 'auto'}}>
          {
            subscriptionPlans !== undefined && (subscriptionPlans.length > 0) ? 
            (
              subscriptionPlans.map((tier) => 
              (
                <Grid
                  key={tier.name}
                  sx={{mb: 5}}
                >
                  <Card>
                    <CardHeader
                      title={tier.name}
                      titleTypographyProps={{ align: 'center' }}
                      subheaderTypographyProps={{
                        align: 'center',
                      }}
                      sx={{
                        backgroundColor: (theme) =>
                          theme.palette.mode === 'light'
                            ? theme.palette.grey[200]
                            : theme.palette.grey[700],
                      }}
                    />
                    <CardContent>
                      <Box
                        sx={{
                          display: 'flex',
                          justifyContent: 'center',
                          alignItems: 'baseline',
                          mb: 2,
                        }}
                      >
                        <Typography component="h2" variant="h3" color="text.primary">
                          ${tier.price/100}
                        </Typography>
                        <Typography variant="h6" color="text.secondary">
                          /mo
                        </Typography>
                      </Box>
                      <Typography>{tier.description}</Typography>
                    </CardContent>
                    <CardActions>
                      <Link to="/Membership/Edit" state={tier} style={{width: '100%'}}>
                      <Button
                        fullWidth
                        variant={'contained'}
                      >
                        Edit Subscription plan
                      </Button>
                      </Link>
                    </CardActions>
                  </Card>
                </Grid>
              )
            )
          ): (
            <Typography>no plans</Typography>
          )
        }
          <Link to="/Membership/New" style={{width: '100%'}}>
            <Button variant='outlined' sx={{mt: 4, mb: 4, left: '20px'}}>
              Create new subscription plan
            </Button>
          </Link>
        </Grid>
      </Container>
    </React.Fragment>
    ) : (
      <React.Fragment>
      <CssBaseline />
      <Container maxWidth="md" component="main">
        <Grid container spacing={5} direction={'column'} item xs={9} sx={{m: 'auto'}}>
          {
            subscriptionPlans !== undefined && (subscriptionPlans.length > 0) ? 
            (
              subscriptionPlans.map((tier) => 
              (
                <Grid
                  key={tier.name}
                  sx={{mb: 5}}
                >
                  <Card>
                    <CardHeader
                      title={tier.name}
                      titleTypographyProps={{ align: 'center' }}
                      subheaderTypographyProps={{
                        align: 'center',
                      }}
                      sx={{
                        backgroundColor: (theme) =>
                          theme.palette.mode === 'light'
                            ? theme.palette.grey[200]
                            : theme.palette.grey[700],
                      }}
                    />
                    <CardContent>
                      <Box
                        sx={{
                          display: 'flex',
                          justifyContent: 'center',
                          alignItems: 'baseline',
                          mb: 2,
                        }}
                      >
                        <Typography component="h2" variant="h3" color="text.primary">
                          ${tier.price/100}
                        </Typography>
                        <Typography variant="h6" color="text.secondary">
                          /mo
                        </Typography>
                      </Box>
                      <Typography>{tier.description}</Typography>
                    </CardContent>
                    <CardActions>
                      <Button
                        fullWidth
                        variant={'contained'}
                      >
                        <Link to="/Checkout" state={tier} style={{textDecoration: 'none', color: 'white'}}>Subscribe for ${tier.price/100}</Link>
                      </Button>
                    </CardActions>
                  </Card>
                </Grid>
              )
            )
          ): (
            <Typography>no plans</Typography>
          )
        }
        </Grid>
      </Container>
    </React.Fragment>
    )}
  </>
  );
}

export default function Membership() {
  return <PricingContent />;
}