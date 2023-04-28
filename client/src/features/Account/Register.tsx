import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import { Button, ButtonGroup } from '@mui/material';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { Link, useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { useAppDispatch } from '../../context/configureStore';
import { FieldValues, useForm } from 'react-hook-form';
import { registerAuthor, registerSubscriber } from './accountSlice';
import { LoadingButton } from '@mui/lab';

function Copyright(props: any) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" to="https://mui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const theme = createTheme();

export default function Register() {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const {register, handleSubmit, formState: {isSubmitting, errors, isValid}} = useForm({
    mode: 'onTouched'
  });

  async function submitSubscriberForm(data: FieldValues) {
    await dispatch(registerSubscriber(data));
    navigate('/');
  }

  async function submitAuthorForm(data: FieldValues) {
    await dispatch(registerAuthor(data));
    navigate('/');
  }
  
  const [choosed, setChoosed] = useState(false);
  const [userType, setUserType] = useState<string | null>(null);
  const chooseType = (type: string) => {
    setUserType(type);
    setChoosed(true);
  }

  if(!choosed) {
    return (
      <ButtonGroup>
          <Button onClick={() => chooseType('subscriber')} variant='contained' color='error'>User</Button>
          <Button onClick={() => chooseType('author')} variant='contained' color='primary'>Author</Button>
      </ButtonGroup>
    )
  }

  function SubscriberRegister() {
    return (
      <ThemeProvider theme={theme}>
          <Container component="main" maxWidth="xs">
            <CssBaseline />
            <Box
              sx={{
                marginTop: 8,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
              }}
            >
              <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                Sign up
              </Typography>
              <Box component="form" onSubmit={handleSubmit(submitSubscriberForm)} noValidate sx={{ mt: 3 }}>
                <Grid container spacing={2}>
                  <Grid item xs={12} sm={6}>
                    <TextField
                      margin='normal'
                      required
                      fullWidth
                      label="First Name"
                      {...register('firstName', {required: 'FirstName is required'})}
                      error={!!errors.firstName}
                      helperText={errors?.firstName?.message as string}
                    />
                  </Grid>
                  <Grid item xs={12} sm={6}>
                    <TextField
                      margin='normal'
                      required
                      fullWidth
                      label="Last Name"
                      {...register('lastName', {required: 'LastName is required'})}
                      error={!!errors.lastName}
                      helperText={errors?.lastName?.message as string}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextField
                      margin='normal'
                      required
                      fullWidth
                      label="Email Address"
                      {...register('email', {required: 'Email is required'})}
                      error={!!errors.email}
                      helperText={errors?.email?.message as string}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextField
                      margin='normal'
                      required
                      fullWidth
                      label="Password"
                      type="password"
                      {...register('password', {required: 'Password is required'})}
                      error={!!errors.password}
                      helperText={errors?.password?.message as string}
                    />
                  </Grid>
                </Grid>
                <LoadingButton
                  loading={isSubmitting}
                  disabled={!isValid} 
                  type="submit"
                  fullWidth
                  variant="contained"
                  sx={{ mt: 3, mb: 2 }}
                >
                  Sign Up
                </LoadingButton>
                <Grid container justifyContent="flex-end">
                  <Grid item>
                    <Link to="/Login">
                      Already have an account? Sign in
                    </Link>
                  </Grid>
                </Grid>
              </Box>
            </Box>
            <Copyright sx={{ mt: 5 }} />
          </Container>
        </ThemeProvider>
    )
  }

  function AuthorRegister() {
    return (
      <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign up
          </Typography>
          <Box component="form" noValidate onSubmit={handleSubmit(submitAuthorForm)} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  label="First Name"
                  {...register('firstName', {required: 'FirstName is required'})}
                  error={!!errors.firstName}
                  helperText={errors?.firstName?.message as string}
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  label="Last Name"
                  {...register('lastName', {required: 'LastName is required'})}
                  error={!!errors.lastName}
                  helperText={errors?.lastName?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Channel Username"
                  {...register('authorUsername', {required: 'Channel Username is required'})}
                  error={!!errors.authorUsername}
                  helperText={errors?.authorUsername?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Email Address"
                  {...register('email', {required: 'Email is required'})}
                  error={!!errors.email}
                  helperText={errors?.email?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  label="Password"
                  type="password"
                  {...register('password', {required: 'Password is required'})}
                  error={!!errors.password}
                  helperText={errors?.password?.message as string}
                />
              </Grid>
              <Grid item xs={12}>
                <FormControlLabel
                  control={<Checkbox value="allowExtraEmails" color="primary" />}
                  label="I want to receive inspiration, marketing promotions and updates via email."
                />
              </Grid>
            </Grid>
            <LoadingButton
              loading={isSubmitting}
              disabled={!isValid}
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </LoadingButton>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link to="/Login">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 5 }} />
      </Container>
    </ThemeProvider>
    )
  }

  if (choosed) {
    if (userType === 'subscriber') {
      return <SubscriberRegister />
    }
    if (userType === 'author') {
      return <AuthorRegister />
    }
  }

  return (
    <div>hello</div>
  )
}