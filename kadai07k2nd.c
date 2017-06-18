// ö‹Æ‚Ì‰Û‘è07k.2nd.c //

#include <stdio.h>

int main(void) 
{
	int n = 7, x[8];
	
	int sp,st,ed,cent,p1,p2,w,i;
	
	int f[100],t[100];
	
	for ( i = 0; i <= 7; i++ )
	{
		printf("®”[%d]-->",i);
		scanf("%d",&x[i]);
	}
	
	sp = 1;
	f[sp] = 0;
	t[sp] = n;
	
	while ( sp > 0 )
	{
		st = f[sp];
		ed = t[sp];
		sp = sp - 1;
		
		while ( st < ed )
		{
			cent = x[((st + ed)/ 2)];
			p1 = st;
			p2 = ed;
			
			while ( p1 <= p2 )
			{
				while ( p1 <= p2 && x[p1] < cent )
				{
					p1 = p1 + 1;
				}
				while ( p1 <= p2 && x[p2] > cent )
				{
					p2 = p2 - 1;
				}
				if ( p1 <= p2 )
				{
					w = x[p1];
					x[p1] = x[p2];
					x[p2] = w;
					
					p1 = p1 + 1;
					
					p2 = p2 - 1;
				}
			}
			if ( ed > p1 )
			{
				sp = sp + 1;
				f[sp] = p1;
				t[sp] = ed;
			}
			
			ed = p2;
		}
	}
	
	printf("\n  * * ƒ\[ƒgŒã * *  \n\n");
	
	for ( i = 0; i <= 7; i++ )
	{
		printf("Œ‹‰Ê[%d]:%d\n",i,x[i]);
	}
	
	return 0;
}