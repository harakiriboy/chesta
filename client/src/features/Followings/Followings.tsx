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
import { Author } from "../../models/Author";
import { Link } from "react-router-dom";

export default function Followings() {
  const [loading, setLoading] = useState(true);
  const [authors, setAuthors] = useState<Author[]>();
  var user = localStorage.getItem('localUser')!;

  useEffect(() => {
    agent.MembersAndAuthors.getSubscriberAuthors(JSON.parse(user).id)
      .then(response => setAuthors(response))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }, [user])

  if(loading) return <LoadingComponent message='Loading subscribers' />
  
  return (
    <TableContainer component={Paper} sx={{p: 10}}>
    <Table sx={{ minWidth: 650 }} aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>Username</TableCell>
          <TableCell>Subject</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {authors!.map((author) => (
          <TableRow
            key={author.authorUsername}
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
          >
            <TableCell component="th" scope="row">
              <Link to={'/'+author.authorUsername}>
              {author.authorUsername}
              </Link>
            </TableCell>
            <TableCell component="th" scope="row">
              {author.tag}
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  </TableContainer>
  );
};