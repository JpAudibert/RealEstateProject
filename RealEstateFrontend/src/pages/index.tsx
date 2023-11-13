import React from 'react';

const Index: React.FC = () => {
  return null;
};

export const getServerSideProps = async () => {
  return { redirect: { destination: '/home', permanent: false } };
};

export default Index;
