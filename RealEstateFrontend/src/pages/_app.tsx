import React from 'react';

import { ChakraProvider } from '@chakra-ui/react';
import { extendTheme } from '@chakra-ui/react';
import SidebarWithHeader from '../components/SideBar';
import { useRouter } from 'next/router';

const colors = {
  brand: {
    900: '#1a365d',
    800: '#153e75',
    700: '#2a69ac',
  },
};

const activeLabelStyles = {
  transform: 'scale(0.85) translateY(-24px)',
};

const theme = extendTheme({
  colors,
  defaultProps: { size: 'lg' },
  components: {
    Form: {
      variants: {
        floating: {
          container: {
            _focusWithin: {
              label: {
                ...activeLabelStyles,
              },
            },
            'input:not(:placeholder-shown) + label, .chakra-select__wrapper + label, textarea:not(:placeholder-shown) ~ label':
              {
                ...activeLabelStyles,
              },
            label: {
              top: 0,
              left: 0,
              zIndex: 2,
              position: 'absolute',
              backgroundColor: 'transparent',
              pointerEvents: 'none',
              mx: 3,
              px: 1,
              my: 2,
              transformOrigin: 'left top',
            },
          },
        },
      },
    },
  },
});

interface AppProps {
  Component: React.FC;
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  pageProps: any;
}

const MyApp: React.FC<AppProps> = ({ Component, pageProps }) => {
  const router = useRouter();

  if (router.pathname === '/login') {
    return (
      <ChakraProvider theme={theme}>
        <Component {...pageProps} />
      </ChakraProvider>
    );
  }

  return (
    <ChakraProvider theme={theme}>
      <SidebarWithHeader>
        <Component {...pageProps} />
      </SidebarWithHeader>
    </ChakraProvider>
  );
};

export default MyApp;
