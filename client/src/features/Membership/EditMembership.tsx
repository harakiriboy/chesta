import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import { Typography } from '@mui/material';
import { LoadingButton } from '@mui/lab';
import { useLocation, useNavigate } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import agent from '../../services/agent';

export default function EditMembership() {
  const location = useLocation();
  const navigate = useNavigate();
  const {register, handleSubmit, formState: {isSubmitting, errors, isValid}} = useForm({
    mode: 'onTouched'
  });

  function submitForm(data: FieldValues) {
    agent.Subscription.editSubscriptionPlan(data);
    navigate('/');
  }
  
  const subscription = location.state;
  return (
    <Container sx={{m: '70px 180px 50px 180px'}}>
      <Typography variant="h4">Edit Subscription Plan</Typography>
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
            <img style={{width: '50%', padding: '20px', top: '50%', left: '50%', margin: '0', position: 'absolute', msTransform: 'translate(-50%, -50%)',
            transform: 'translate(-50%, -50%)'}} src={require("../../assets/images/view-edit.png")} alt="kek"/>
          </div>
          <div  style={{width: '50%'}}>
            <div style={{marginBottom: '40px', marginTop: '40px'}}>
              <TextField
                sx={{width: {sm: 200, md: 300}}}
                required
                id="outlined-required"
                label="Name"
                placeholder="Example"
                defaultValue={subscription.name}
                {...register('name', {required: 'Name is required'})}
                error={!!errors.name}
                helperText={errors?.name?.message as string}
              />
            </div>
            <div  style={{marginBottom: '40px'}}>
            <TextField
                id="outlined-disabled"
                label="Description"
                multiline
                placeholder="Thi is the desciption for my subscription plan"
                defaultValue={subscription.description}
                {...register('description', {required: 'Description is required'})}
                error={!!errors.description}
                helperText={errors?.description?.message as string}
              />
            </div>
            <div  style={{marginBottom: '40px'}}>
            <TextField
                id="outlined-disabled"
                label="Price"
                defaultValue={subscription.price}
                {...register('price', {required: 'Price is required'})}
                error={!!errors.price}
                helperText={errors?.price?.message as string}
              />
            </div>
            <TextField
                sx={{display: 'none'}}
                defaultValue={subscription.id}
                {...register('id', {required: 'Price is required'})}
                error={!!errors.id}
                helperText={errors?.id?.message as string}
              />
            <div style={{marginBottom: '40px'}}>
              <LoadingButton
                  loading={isSubmitting}
                  disabled={!isValid}
                  type="submit"
                  variant="contained"
                  sx={{ mt: 3, mb: 2, width: '78%' }}
                >
                  Edit Subscription
              </LoadingButton>
            </div>
          </div>
        </div>
    </Box>
    </Container>
  );
}