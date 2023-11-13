import Head from 'next/head';
import React, { useEffect, useState } from 'react';
import router from 'next/router';
import ListCard from '../components/ListCard/ListCard';

const Home: React.FC = () => {
  const [token, setToken] = useState<string>('');

  useEffect(() => {
    const storageToken = localStorage.getItem('user');

    if (storageToken === null) {
      router.push('/login');
    }
    setToken(storageToken!);
  }, [token]);

  return (
    <>
      <Head>
        <title>Home - Buscar imóvel</title>
      </Head>
      <ListCard />
    </>
  );
};

export default Home;
