import React, { useEffect, useState } from "react";
import agent from "../../services/agent";
import LoadingComponent from "../../layouts/Loading/LoadingComponent";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

interface Subscriber {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
}

export default function Members() {
  const [loading, setLoading] = useState(true);
  const [subscribers, setSubscribers] = useState<Subscriber[]>();
  var author = localStorage.getItem('localAuthor')!;

  useEffect(() => {
    agent.MembersAndAuthors.getAuthorSubscribers(author)
      .then(response => setSubscribers(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [author])

  if(loading) return <LoadingComponent message='Loading subscribers' />
  
  return (
    <TableContainer component={Paper} sx={{p: 10}}>
    <Table sx={{ minWidth: 650 }} aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>User Id</TableCell>
          <TableCell>FirstName</TableCell>
          <TableCell>LastName</TableCell>
          <TableCell>Email</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {subscribers!.map((subscriber) => (
          <TableRow
            key={subscriber.id}
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
          >
            <TableCell component="th" scope="row">
              {subscriber.id}
            </TableCell>
            <TableCell component="th" scope="row">
              {subscriber.firstName}
            </TableCell>
            <TableCell component="th" scope="row">
              {subscriber.lastName}
            </TableCell>
            <TableCell component="th">{subscriber.email}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  </TableContainer>
  );
};