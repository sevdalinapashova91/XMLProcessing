<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">
      <html>
        <body>
          <h1>Albums</h1>
           <xsl:for-each select="catalogue/album">
             <h1>Name:
                <xsl:value-of select="name"/>
             </h1>
             <h5>Artist:
               <xsl:value-of select="artist"/>
             </h5>
              <h5>Year:
               <xsl:value-of select="year"/>
             </h5>
              <h5>Producer:
               <xsl:value-of select="producer"/>
             </h5>
             <h5>List of songs</h5>
               <xsl:for-each select="songs/song">
                 <h5>
                   Title:
                   <xsl:value-of select="title"/>
                 </h5>
                 <h5>
                   Diration:
                   <xsl:value-of select="duration"/>
                 </h5>
               </xsl:for-each>            
          </xsl:for-each>      
        
        </body>      
      </html>
    </xsl:template>
</xsl:stylesheet>
