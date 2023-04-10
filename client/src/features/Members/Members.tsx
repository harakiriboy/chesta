import React from "react";

interface Subscriber {
    id: number;
    name: string;
    email: string;
    level: string;
    payment: number;
    status: string;
    subscribedDate: string;
    lastPaymentDate: string;
}

interface TableProps {
    data: Subscriber[];
}

const members: Subscriber[] = [
    {
      id: 0,
      name: "John Doe",
      email: "johndoe@gmail.com",
      level: "Beginner",
      payment: 50,
      status: "Active",
      subscribedDate: "2022-01-01",
      lastPaymentDate: "2022-02-01",
    },
    {
      id: 1,
      name: "Jane Smith",
      email: "janesmith@gmail.com",
      level: "Medium",
      payment: 75,
      status: "Active",
      subscribedDate: "2022-01-05",
      lastPaymentDate: "2022-02-05",
    },
    {
      id: 2,
      name: "Bob Johnson",
      email: "bobjohnson@gmail.com",
      level: "Expert",
      payment: 100,
      status: "Inactive",
      subscribedDate: "2022-01-10",
      lastPaymentDate: "2022-02-10",
    },
    {
      id: 3,
      name: "Sara Lee",
      email: "saralee@gmail.com",
      level: "Beginner",
      payment: 50,
      status: "Active",
      subscribedDate: "2022-01-15",
      lastPaymentDate: "2022-02-15",
    },
    {
      id: 4,
      name: "Mike Adams",
      email: "mikeadams@gmail.com",
      level: "Expert",
      payment: 100,
      status: "Active",
      subscribedDate: "2022-01-20",
      lastPaymentDate: "2022-02-20",
    },
    {
        id: 5,
      name: "Anna Kim",
      email: "annakim@gmail.com",
      level: "Medium",
      payment: 75,
      status: "Inactive",
      subscribedDate: "2022-01-25",
      lastPaymentDate: "2022-02-25",
    },
    {
        id: 6,
      name: "David Lee",
      email: "davidlee@gmail.com",
      level: "Expert",
      payment: 100,
      status: "Active",
      subscribedDate: "2022-02-01",
      lastPaymentDate: "2022-03-01",
    },
    {
        id: 7,
      name: "Grace Park",
      email: "gracepark@gmail.com",
      level: "Beginner",
      payment: 50,
      status: "Inactive",
      subscribedDate: "2022-02-05",
      lastPaymentDate: "2022-03-05",
    },
    {
        id: 8,
      name: "Mark Lee",
      email: "marklee@gmail.com",
      level: "Medium",
      payment: 75,
      status: "Active",
      subscribedDate: "2022-02-10",
      lastPaymentDate: "2022-03-10",
    },
    {
        id: 9,
      name: "Karen Choi",
      email: "karenchoi@gmail.com",
      level: "Beginner",
      payment: 50,
      status: "Active",
      subscribedDate: "2022-02-15",
      lastPaymentDate: "2022-03-15",
    },
  ];

const Members: React.FC<TableProps> = ({ data }) => {
    data = members;
    return (
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>Current Level</th>
            <th>Payment</th>
            <th>Status</th>
            <th>Subscribed Date</th>
            <th>Last Payment Date</th>
          </tr>
        </thead>
        <tbody>
          {data.map((subscriber) => (
            <tr key={subscriber.id}>
              <td>{subscriber.id}</td>
              <td>{subscriber.name}</td>
              <td>{subscriber.email}</td>
              <td>{subscriber.level}</td>
              <td>{subscriber.payment}</td>
              <td>{subscriber.status}</td>
              <td>{subscriber.subscribedDate}</td>
              <td>{subscriber.lastPaymentDate}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
};
  
export default Members;