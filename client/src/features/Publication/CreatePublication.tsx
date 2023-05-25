import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import { Typography, FormControl, FormLabel, RadioGroup, FormControlLabel, Radio } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import agent from '../../services/agent';
import { LoadingButton } from '@mui/lab';
import { useEffect, useState } from 'react';
import LoadingComponent from '../../layouts/Loading/LoadingComponent';
import NoAccess from '../../components/NoAccess';
import { toast } from 'react-toastify';

export default function CreatePublication() {
  const [userType, setUserType] = useState<string>("");
  const [subscriptionPlans, setSubscriptionPlans] = useState([
    {id: 1, name: "some name"}
  ]);

  const [loading, setLoading] = useState(true);
  
  useEffect(() => {
    var user = JSON.parse(localStorage.getItem('localUser')!);
    if (user !== null || user !== undefined) {
      setUserType(user.role);
    }
    agent.Subscription.listPlans(localStorage.getItem('localAuthor')!)
      .then(response => setSubscriptionPlans(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false))
  }, []);

  const navigate = useNavigate();
  const {register, handleSubmit, formState: {isSubmitting, errors, isValid}} = useForm({
    mode: 'onTouched'
  });

  function submitForm(data: FieldValues) {
    agent.Publication.createPublication(data)
      .then(response => toast.success('Post created successfully'))
      .catch(error => toast.error('There is some error'));
    navigate('/');
  }

  if(loading) return <LoadingComponent message='Loading subscription plans' />
  if(userType === 'subscriber') return <NoAccess/>

  return (
    <Container sx={{m: '70px 180px 0 180px'}}>
      <Typography variant="h4">New Publication</Typography>
      <br/>
      <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 1, width: '50ch' },
          border: '1px solid grey',
          borderRadius: '10px',
        }}
        noValidate
        autoComplete="off"
        onSubmit={handleSubmit(submitForm)}
      >
      <div className='row' style={{display: 'flex'}}>
          <div style={{width: '50%', position: 'relative'}}>
            <img style={{width: '70%', padding: '20px', top: '50%', left: '50%', margin: '0', position: 'absolute', msTransform: 'translate(-50%, -50%)',
            transform: 'translate(-50%, -50%)'}} src='https://t4.ftcdn.net/jpg/04/64/96/91/360_F_464969171_EhrkPWQOrARbuyIHL8Na6H6OzJkYZwwQ.jpg' alt="kek"/>
          </div>
          <div  style={{width: '50%'}}>
            <div style={{marginBottom: '10px', marginTop: '20px'}}>
              <TextField
                sx={{width: {sm: 200, md: 300}}}
                required
                id="outlined-required"
                label="Title"
                defaultValue="Hello World"
                {...register('title', {required: 'Title is required'})}
                error={!!errors.title}
                helperText={errors?.title?.message as string}
              />
            </div>
            <div  style={{marginBottom: '10px'}}>
            <TextField
                id="outlined-disabled"
                label="Description"
                defaultValue="This is dummy description"
                {...register('text', {required: 'Description is required'})}
                error={!!errors.description}
                helperText={errors?.description?.message as string}
              />
            </div>
            <div style={{marginBottom: '20px'}}>
              <TextField
                required
                id="filled-required"
                label="Video Link"
                variant="filled"
                {...register('videoLink', {required: 'Video Link is required'})}
                error={!!errors.link}
                helperText={errors?.link?.message as string}
              />
            </div>
            <div style={{marginBottom: '10px'}}>
              <FormControl sx={{right: '70px'}}>
                <FormLabel id="demo-row-radio-buttons-group-label" sx={{right: '80px'}}>Subscription plan</FormLabel>
                <RadioGroup
                  row
                  aria-labelledby="demo-row-radio-buttons-group-label"
                >
                  {subscriptionPlans.map((o) => <FormControlLabel {...register('subscriptionPlanId', {required: 'Subscription Plan is required'})} key={o.id} value={o.id} control={<Radio />} label={o.name} />)}
                </RadioGroup>
              </FormControl>
            </div>
            <div style={{marginBottom: '20px'}}>
              <LoadingButton
                loading={isSubmitting}
                disabled={!isValid}
                type="submit"
                variant="contained"
                sx={{ mt: 3, mb: 2, width: '78%' }}
              >
                Create Publication
              </LoadingButton>
            </div>  
          </div>
        </div>
    </Box>
    </Container>
  );
}